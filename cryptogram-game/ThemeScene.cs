using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeScene : MonoBehaviour
{
    // prefab objects for the UI elements
    public GameObject disFab, famFab, popFab, txtFab;

    // Start is called before the first frame update
    void Start()
    {
        // create associated UI elements for theme scene
        createObjects();
    }

    void createObjects()
    {
        var canvas = GameObject.Find("Canvas");

        // disney button
        var disney = Instantiate(disFab);
        var disX = canvas.GetComponent<RectTransform>().position.x + .5f;
        var disY = canvas.GetComponent<RectTransform>().position.y - 36;

        var disButton = disney.GetComponent<Button>();
        disButton.GetComponent<RectTransform>().SetParent(canvas.transform);
        disButton.transform.position = new Vector3(disX, disY, 0);
        disButton.onClick.AddListener(disneyClicked);

        // famous quotes button
        var famous = Instantiate(famFab);
        var famX = canvas.GetComponent<RectTransform>().position.x + .5f;
        var famY = canvas.GetComponent<RectTransform>().position.y - 118;

        var famButton = famous.GetComponent<Button>();
        famButton.GetComponent<RectTransform>().SetParent(canvas.transform);
        famButton.transform.position = new Vector3(famX, famY, 0);
        famButton.onClick.AddListener(famousClicked);

        // popular button
        var popular = Instantiate(popFab);
        var popX = canvas.GetComponent<RectTransform>().position.x;
        var popY = canvas.GetComponent<RectTransform>().position.y - 78;

        var popButton = popular.GetComponent<Button>();
        popButton.GetComponent<RectTransform>().SetParent(canvas.transform);
        popButton.transform.position = new Vector3(popX, popY, 0);
        popButton.onClick.AddListener(popularClicked);

        // select theme text
        var txt = Instantiate(txtFab);
        var textX = canvas.GetComponent<RectTransform>().position.x + .5f;
        var textY = canvas.GetComponent<RectTransform>().position.y + 2;

        var selectTheme = txt.GetComponent<Text>();
        selectTheme.GetComponent<RectTransform>().SetParent(canvas.transform);
        selectTheme.transform.position = new Vector3(textX, textY, 0);
    }

    void disneyClicked()
    {
        // testing output
        Debug.Log("Disney button clicked");

        var gameManager = GameObject.FindObjectOfType<GmManager>();

        // destroy Theme Scene objects
        Object[] startObjects = GameObject.FindGameObjectsWithTag("Theme");
        foreach (GameObject obj in startObjects)
        {
            Destroy(obj);
        }

        // get Disney themed cryptogram from levels
        var selected_text = LevelScript.GetDisneyLevel();
        gameManager.receivedLevel(selected_text);
    }

    void famousClicked()
    {
        // testing output
        Debug.Log("Famous button clicked");

        var gameManager = GameObject.FindObjectOfType<GmManager>();

        // destroy StartScene objects
        Object[] startObjects = GameObject.FindGameObjectsWithTag("Theme");
        foreach (GameObject obj in startObjects)
        {
            Destroy(obj);
        }

        // get Famous Quotes themed cryptogram from levels
        var selected_text = LevelScript.GetFamousQuoteLevel();
        gameManager.receivedLevel(selected_text);
    }

    void popularClicked()
    {
        // testing output
        Debug.Log("Popular button clicked");

        var gameManager = GameObject.FindObjectOfType<GmManager>();

        // destroy StartScene objects
        Object[] startObjects = GameObject.FindGameObjectsWithTag("Theme");
        foreach (GameObject obj in startObjects)
        {
            Destroy(obj);
        }

        // get Pop music themed cryptogram from level
        var selected_text = LevelScript.GetPopMusicLevel();
        gameManager.receivedLevel(selected_text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
