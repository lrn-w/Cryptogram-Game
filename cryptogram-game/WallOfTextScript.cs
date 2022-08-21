using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;

public class WallOfTextScript : MonoBehaviour
{
    public GameObject PrefabGameObject;

    private List<GameObject> PreFabs { get; set; }

    public Difficulty SelectedDifficulty { get; set; } = Difficulty.Normal;

    public int WidthOfColumn;
    public int HeightOfRow;

    public GameObject menu;

    // Start is called before the first frame update
    public void Start()
    {

    }

    /// <summary>
    /// Initializes the Wall of Text
    /// </summary>
    /// <param name="levelText">The unencrypted level text</param>
    public void Initialize(string levelText)
    {
        // make menu available
        menu.SetActive(true);

        // Clears out PreFabs with new list
        // PreFabs = new List<GameObject>();
        PreFabs = new List<GameObject>();

        InitializeCryptogramModel(levelText);
        InitializePreFabs();
        InitializeSeconds();
    }

    /// <summary>
    /// Initializes the Seconds PreFab
    /// </summary>
    private void InitializeSeconds()
    {
        switch (SelectedDifficulty)
        {
            case Difficulty.Easy:
                SecondsLeft = 180;
                break;
            case Difficulty.Normal:
                SecondsLeft = 150;
                break;
            case Difficulty.Hard:
                SecondsLeft = 120;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        // make visible
        var secondsLeft = GameObject.Find("Canvas").transform.Find("SecondsLeft").gameObject;
        secondsLeft.SetActive(true);

        UpdateSecondsPrefab(SecondsLeft);
    }

    private void UpdateSecondsPrefab(int seconds)
    {
        // Get the GameObject Canvas from the Scene
        var secondsLeftPreFab = GameObject.Find("Seconds").GetComponent<Text>();
        secondsLeftPreFab.text = seconds.ToString();
    }

    /// <summary>
    /// Initializes the CryptogramModel with the level text
    /// </summary>
    /// <param name="levelText">The unencrypted level text</param>
    private void InitializeCryptogramModel(string levelText)
    {
        var cryptogramModel = GameObject.Find("Canvas").GetComponent<CryptogramModel>();

        cryptogramModel.Initialize(levelText);
    }

    /// <summary>
    /// Creates the Prefabs based off the CryptogramModel
    /// </summary>
    private void InitializePreFabs()
    {
        PreFabs = new List<GameObject>();

        // Get the GameObject Canvas from the Scene
        var canvasGameObject = GameObject.Find("Canvas");

        var minX = canvasGameObject.GetComponent<RectTransform>().position.x +
                     canvasGameObject.GetComponent<RectTransform>().rect.xMin;
        var maxY = canvasGameObject.GetComponent<RectTransform>().position.y +
                     canvasGameObject.GetComponent<RectTransform>().rect.yMax;

        // Get the CryptogramModel from the Canvas
        var cryptogramModel = canvasGameObject.GetComponent<CryptogramModel>();

        // Initialize currentRow and currentColumn height/width used for spacing
        var currentRow = HeightOfRow + 50;
        var currentColumn = WidthOfColumn;

        // Create Prefabs for each char in EncryptedText
        for (var index = 0; index < cryptogramModel.EncryptedText.Length; index++)
        {
            if (currentColumn > canvasGameObject.GetComponent<RectTransform>().rect.xMax * 2 - WidthOfColumn)
            {
                currentColumn = WidthOfColumn;
                currentRow += HeightOfRow;
            }

            var newPrefab = Instantiate(PrefabGameObject, new Vector3(minX + currentColumn, maxY - currentRow, 0),
                Quaternion.identity);

            // Set Parent of Prefab to Canvas
            newPrefab.transform.parent = canvasGameObject.transform;

            // Set Prefab EncryptedChar from CryptogramModel EncryptedText
            newPrefab.transform.Find("EncryptedChar").GetComponent<Text>().text = cryptogramModel.EncryptedText[index].ToString();

            // Set Prefab UserInput from CryptogramModel EncryptedText
            newPrefab.transform.Find("UserInput").GetComponent<InputField>().text = cryptogramModel.StartingUserDecryptedText[index].ToString();

            // set highlighted color to random color
            var colors = newPrefab.transform.Find("UserInput").GetComponent<InputField>().colors;
            colors.highlightedColor = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);

            newPrefab.transform.Find("UserInput").GetComponent<InputField>().colors = colors;
            PreFabs.Add(newPrefab);

            currentColumn += WidthOfColumn;
        }

        // move Panel in hierarchy so that it is in front of wall of text        
        var panel = canvasGameObject.transform.Find("Panel").gameObject;
        panel.transform.SetAsLastSibling();
        menu.transform.SetAsLastSibling();
    }

    // Update is called once per frame
    public void Update()
    {
        var gameManager = GameObject.FindObjectOfType<GmManager>();

        if (PreFabs == null || PreFabs.Count == 0)
        {
            return;
        }

        CheckAndPropagateCharChanges();

        if (Time.time >= NextUpdateSecond)
        {
            // Change the next update (current second+1)
            NextUpdateSecond = Mathf.FloorToInt(Time.time) + 1;

            // Subtract a second from Seconds Left
            SecondsLeft -= 1;

            UpdateSecondsPrefab(SecondsLeft);
        }
        else
        {
            return;
        }

        AutoSolver();

        // Win Condition
        if (CheckForWin())
        {
            // destroy WallOfText objects
            PreFabs.Clear();
            PreviousUpdateEncryptedValues.Clear();

            var wallObjects = GameObject.FindGameObjectsWithTag("WallOfText");
            foreach (var obj in wallObjects)
            {
                Destroy(obj);
            }

            // hide seconds when going to end scene?
            var secondsLeft = GameObject.Find("Canvas").transform.Find("SecondsLeft").gameObject;
            secondsLeft.SetActive(false);


            gameManager.gameEnd(CalculateScore());
        }

        // Lose Condition
        if (SecondsLeft <= 0)
        {
            // destroy WallOfText objects
            PreFabs.Clear();
            PreviousUpdateEncryptedValues.Clear();

            var wallObjects = GameObject.FindGameObjectsWithTag("WallOfText");
            foreach (var obj in wallObjects)
            {
                Destroy(obj);
            }

            // hide seconds when going to end scene?
            var secondsLeft = GameObject.Find("Canvas").transform.Find("SecondsLeft").gameObject;
            secondsLeft.SetActive(false);

            gameManager.gameEnd(CalculateScore());
        }
    }

    private int CalculateScore()
    {
        if (SecondsLeft == 0)
        {
            return 0;
        }

        var score = 0;
        switch (SelectedDifficulty)
        {
            case Difficulty.Easy:
                score += SecondsLeft * 1;
                score += 50;
                break;
            case Difficulty.Normal:
                score += SecondsLeft * 3;
                score += 100;
                break;
            case Difficulty.Hard:
                score += SecondsLeft * 5;
                score += 150;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return score;
    }

    // used by menu to clear prefab lists when changing scenes
    public void clearLists()
    {
        PreFabs.Clear();
        PreviousUpdateEncryptedValues.Clear();
    }

    private void AutoSolver()
    {
        if (SelectedDifficulty == Difficulty.Easy)
        {
            // Solve every 5 seconds
            if (SecondsLeft % 5 == 0)
            {
                SolveACharacter();
            }
        }

        if (SelectedDifficulty == Difficulty.Normal)
        {
            // Solve every 15 seconds
            if (SecondsLeft % 15 == 0)
            {
                SolveACharacter();
            }
        }
    }

    private void SolveACharacter()
    {
        var cryptogramModel = GameObject.Find("Canvas").GetComponent<CryptogramModel>();

        var currentUserInput = new List<char>();
        // Create copy of current User Input
        foreach (var currentPreFab in PreFabs)
        {
            var preFabCharValue = currentPreFab.transform.Find("UserInput").GetComponent<InputField>().text.FirstOrDefault();
            currentUserInput.Add(preFabCharValue);
        }

        var incorrectCharPositions = new List<int>();
        // Get locations for all incorrect character
        for (var i = 0; i < cryptogramModel.OriginalDecryptedText.Length; i++)
        {
            if (currentUserInput[i] != cryptogramModel.OriginalDecryptedText[i])
            {
                incorrectCharPositions.Add(i);
            }
        }

        var random = new System.Random();

        try
        {
            // Get a random position from the incorrectCharPositions
            var randomPositionForIncorrectCharPositions = random.Next(incorrectCharPositions.Count);

            // Gets a random position in the list
            var randomListPosition = incorrectCharPositions[randomPositionForIncorrectCharPositions];

            // Replaces an incorrect character with a correct one
            PreFabs[randomListPosition].transform.Find("UserInput").GetComponent<InputField>().text = cryptogramModel.OriginalDecryptedText[randomListPosition].ToString();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private List<char> PreviousUpdateEncryptedValues { get; set; }
    private void CheckAndPropagateCharChanges()
    {
        var currentUserInput = new List<char>();
        // Create copy of current User Input
        foreach (var currentPreFab in PreFabs)
        {
            var preFabCharValue = currentPreFab.transform.Find("UserInput").GetComponent<InputField>().text.FirstOrDefault();
            currentUserInput.Add(preFabCharValue);
        }

        for (var i = 0; i < PreviousUpdateEncryptedValues?.Count; i++)
        {
            // A change has occurred
            if (currentUserInput[i] == PreviousUpdateEncryptedValues[i])
            {
                continue;
            }

            var encryptedCharPairingForChangedInput = PreFabs[i].transform.Find("EncryptedChar").GetComponent<Text>().text.FirstOrDefault();
            foreach (var preFab in PreFabs)
            {
                var preFabCharValue = preFab.transform.Find("EncryptedChar").GetComponent<Text>().text.FirstOrDefault();
                // Look for prefabs that have the same matching Encrypted pairing
                if (preFabCharValue == encryptedCharPairingForChangedInput)
                {
                    // Change user input to match changed user input
                    preFab.transform.Find("UserInput").GetComponent<InputField>().text =
                        currentUserInput[i].ToString().ToUpper();
                }
            }
        }

        // Set PreviousUpdateEncryptedValues to Current User Input
        PreviousUpdateEncryptedValues = currentUserInput;
    }

    private bool CheckForWin()
    {
        var decryptedCharList = new List<char>();

        // Extract the char from the PreFabs into decryptedCharList
        foreach (var prefabGameObject in PreFabs)
        {
            decryptedCharList.Add(prefabGameObject.transform.Find("UserInput").GetComponent<InputField>().text.FirstOrDefault());
        }

        // Find CryptogramModel in Canvas
        var cryptogramModel = GameObject.Find("Canvas").GetComponent<CryptogramModel>();

        // Test decryptedCharList for win against cryptogramModel
        return cryptogramModel.CryptogramSolved(decryptedCharList.ToArray());
    }

    // The next second that the timer needs to be updated at
    private int NextUpdateSecond { get; set; } = 1;

    // Seconds left on the game timer
    private int SecondsLeft { get; set; }

    public void ChangeToEasyDifficulty()
    {
        SecondsLeft = 180;
        SelectedDifficulty = Difficulty.Easy;
    }

    public void ChangeToNormalDifficulty()
    {
        SecondsLeft = 120;
        SelectedDifficulty = Difficulty.Normal;
    }

    public void ChangeToHardDifficulty()
    {
        SecondsLeft = 120;
        SelectedDifficulty = Difficulty.Hard;
    }
}

public enum Difficulty
{
    Easy,
    Normal,
    Hard
}