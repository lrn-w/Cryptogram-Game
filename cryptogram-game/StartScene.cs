using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    public GameObject randomPre, themePre, textPre;

    // Start is called before the first frame update
    void Start()
    {
        // Dynamically create the UI elements from the Start scene
        createObjects();
        
    }

    void createObjects()
    {
        // variable declaration
        // random button
        var canvas = GameObject.Find("Canvas");
        var ran = Instantiate(randomPre);

        var ranX = canvas.GetComponent<RectTransform>().position.x - 12;
        var ranY = canvas.GetComponent<RectTransform>().position.y - 42;

        var randomButton = ran.GetComponent<Button>();
        randomButton.GetComponent<RectTransform>().SetParent(canvas.transform);
        randomButton.transform.position = new Vector3(ranX, ranY, 0);
        randomButton.onClick.AddListener(randomClicked);

        // theme button
        var theme = Instantiate(themePre);
        var themeX = canvas.GetComponent<RectTransform>().position.x - 12;
        var themeY = canvas.GetComponent<RectTransform>().position.y - 80;

        var themeButton = theme.GetComponent<Button>();
        themeButton.GetComponent<RectTransform>().SetParent(canvas.transform);
        themeButton.transform.position = new Vector3(themeX, themeY, 0);
        themeButton.onClick.AddListener(themeClicked);

        // welcome text
        var txt = Instantiate(textPre);

        var textX = canvas.GetComponent<RectTransform>().position.x - 12;
        var textY = canvas.GetComponent<RectTransform>().position.y - 10;

        var welcome = txt.GetComponent<Text>();
        welcome.GetComponent<RectTransform>().SetParent(canvas.transform);
        welcome.transform.position = new Vector3(textX, textY, 0);
    }
    void randomClicked()
    {
        // testing output
        Debug.Log("Random button clicked");

        var gameManager = GameObject.FindObjectOfType<GmManager>();

        // destroy StartScene objects
        Object[] startObjects = GameObject.FindGameObjectsWithTag("Start");
        foreach (GameObject obj in startObjects)
        {
            Destroy(obj);
        }

        // get random cryptogram to pass to game manager
        var selected_text = LevelScript.GetRandomlevel();
        gameManager.receivedLevel(selected_text);

    }

    // Selecting the theme button will redirect to Theme level.
    void themeClicked()
    {
        var gameManager = GameObject.FindObjectOfType<GmManager>();

        // testing output
        Debug.Log("Theme button clicked.");

        // destroy StartScene objects
        Object[] startObjects = GameObject.FindGameObjectsWithTag("Start");
        foreach (GameObject obj in startObjects)
        {
            Destroy(obj);
        }
        gameManager.goToTheme();
       
    }
}
