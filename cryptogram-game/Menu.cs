
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void themeClicked()
    {
        var gameManager = GameObject.FindObjectOfType<GmManager>();

        Debug.Log("Theme button clicked");

        var wallOfText = GameObject.FindObjectOfType<WallOfTextScript>();
        wallOfText.clearLists();

        var GameObjects = FindObjectsOfType<GameObject>();

        foreach (var obj in GameObjects)
        {
            if (!(obj.tag == "main" || obj.tag == "MainCamera"))
            {
                Destroy(obj);
            }

        }

        gameManager.goToTheme();
    }

    public void randomClicked()
    {
        var gameManager = GameObject.FindObjectOfType<GmManager>();

        Debug.Log("Theme button clicked");

        var wallOfText = GameObject.FindObjectOfType<WallOfTextScript>();
        wallOfText.clearLists();

        var GameObjects = FindObjectsOfType<GameObject>();

        foreach (var obj in GameObjects)
        {
            if (!(obj.tag == "main" || obj.tag == "MainCamera"))
            {
                Destroy(obj);
            }

        }

        // get random cryptogram to pass to game manager
        var selected_text = LevelScript.GetRandomlevel();
        gameManager.receivedLevel(selected_text);
    }

    public void difficultyClicked()
    {
        var gameManager = GameObject.FindObjectOfType<GmManager>();

        Debug.Log("Difficulty button clicked");

        var wallOfText = GameObject.FindObjectOfType<WallOfTextScript>();
        wallOfText.clearLists();

        var GameObjects = FindObjectsOfType<GameObject>();

        foreach (var obj in GameObjects)
        {
            if (!(obj.tag == "main" || obj.tag == "MainCamera"))
            {
                Destroy(obj);
            }

        }

        gameManager.goToDifficulty();
    }

    public void quitGame()
    {
        var gameManager = GameObject.FindObjectOfType<GmManager>();

        Debug.Log("Quit button clicked");

        var wallOfText = GameObject.FindObjectOfType<WallOfTextScript>();
        wallOfText.clearLists();

        var GameObjects = FindObjectsOfType<GameObject>();

        foreach (var obj in GameObjects)
        {
            if (!(obj.tag == "main" || obj.tag == "MainCamera"))
            {
                Destroy(obj);
            }

        }

        // hide seconds when going to end scene?
        var secondsLeft = GameObject.Find("Canvas").transform.Find("SecondsLeft").gameObject;
        secondsLeft.SetActive(false);

        gameManager.gameEnd(0);
    }

}
