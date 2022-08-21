using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyScene : MonoBehaviour
{
    public GameObject diffText, easyFab, normFab, hardFab;
    // Start is called before the first frame update
    void Start()
    {
        // Dynamically create the UI elements from Difficulty Scene
        createObjects();
    }

    void createObjects()
    {
        var canvas = GameObject.Find("Canvas");

        // easy button
        var easy = Instantiate(easyFab);
        var easyX = canvas.GetComponent<RectTransform>().position.x -2;
        var easyY = canvas.GetComponent<RectTransform>().position.y - 36;

        var easyButton = easy.GetComponent<Button>();
        easyButton.GetComponent<RectTransform>().SetParent(canvas.transform);
        easyButton.transform.position = new Vector3(easyX, easyY, 0);
        easyButton.onClick.AddListener(easyClicked);

        // normal button
        var famous = Instantiate(normFab);
        var normX = canvas.GetComponent<RectTransform>().position.x -2;
        var normY = canvas.GetComponent<RectTransform>().position.y - 78;

        var normButton = famous.GetComponent<Button>();
        normButton.GetComponent<RectTransform>().SetParent(canvas.transform);
        normButton.transform.position = new Vector3(normX, normY, 0);
        normButton.onClick.AddListener(normClicked);

        // hard button
        var hard = Instantiate(hardFab);
        var hardX = canvas.GetComponent<RectTransform>().position.x -2;
        var hardY = canvas.GetComponent<RectTransform>().position.y - 118;

        var hardButton = hard.GetComponent<Button>();
        hardButton.GetComponent<RectTransform>().SetParent(canvas.transform);
        hardButton.transform.position = new Vector3(hardX, hardY, 0);
        hardButton.onClick.AddListener(hardClicked);

        // select difficulty text
        var txt = Instantiate(diffText);
        var textX = canvas.GetComponent<RectTransform>().position.x -6;
        var textY = canvas.GetComponent<RectTransform>().position.y + 7;

        var selectDiff = txt.GetComponent<Text>();
        selectDiff.GetComponent<RectTransform>().SetParent(canvas.transform);
        selectDiff.transform.position = new Vector3(textX, textY, 0);
    }

    void easyClicked()
    {
        // testing output
        Debug.Log("Easy button clicked");

        var gameManager = GameObject.FindObjectOfType<GmManager>();

        var wallOfText = GameObject.FindObjectOfType<WallOfTextScript>();

        // destroy Theme Scene objects
        Object[] diffObjects = GameObject.FindGameObjectsWithTag("Difficulty");
        foreach (GameObject obj in diffObjects)
        {
            Destroy(obj);
        }
        
        wallOfText.ChangeToEasyDifficulty();

        // hide cryptogram title
        if (GameObject.Find("Canvas").transform.Find("Cryptogram").gameObject.activeSelf == true)
        {
            var cryptogram = GameObject.Find("Cryptogram");
            cryptogram.SetActive(false);
        }
        

        gameManager.receivedDifficulty();
    }

    void normClicked()
    {
        // testing output
        Debug.Log("Normal button clicked");

        var gameManager = GameObject.FindObjectOfType<GmManager>();

        var wallOfText = GameObject.FindObjectOfType<WallOfTextScript>();

        // destroy StartScene objects
        Object[] diffObjects = GameObject.FindGameObjectsWithTag("Difficulty");
        foreach (GameObject obj in diffObjects)
        {
            Destroy(obj);
        }

        wallOfText.ChangeToNormalDifficulty();

        // hide cryptogram title
        if (GameObject.Find("Canvas").transform.Find("Cryptogram").gameObject.activeSelf == true)
        {
            var cryptogram = GameObject.Find("Cryptogram");
            cryptogram.SetActive(false);
        }

        gameManager.receivedDifficulty();
    }

    void hardClicked()
    {
        // testing output
        Debug.Log("Hard button clicked");

        var gameManager = GameObject.FindObjectOfType<GmManager>();

        var wallOfText = GameObject.FindObjectOfType<WallOfTextScript>();

        // destroy StartScene objects
        Object[] diffObjects = GameObject.FindGameObjectsWithTag("Difficulty");
        foreach (GameObject obj in diffObjects)
        {
            Destroy(obj);
        }

        wallOfText.ChangeToHardDifficulty();

        // hide cryptogram title
        if (GameObject.Find("Canvas").transform.Find("Cryptogram").gameObject.activeSelf == true)
        {
            var cryptogram = GameObject.Find("Cryptogram");
            cryptogram.SetActive(false);
        }

        gameManager.receivedDifficulty();
    }
   
}
