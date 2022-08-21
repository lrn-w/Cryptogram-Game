using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    public GameObject gmOverFab, scoreFab, returnFab;

    [HideInInspector]
    static public int score_;

    // Start is called before the first frame update
    void Start()
    {
        createObjects();
    }

    static public void setScore(int score)
    {
        score_ = score;
    }
    //TODO: static? pass in score from game manager.
    void createObjects()
    {
        var canvas = GameObject.Find("Canvas");

        // game over text
        var gameOv = Instantiate(gmOverFab);
        var gameX = canvas.GetComponent<RectTransform>().position.x;
        var gameY = canvas.GetComponent<RectTransform>().position.y + 34;

        var gameOver = gameOv.GetComponent<Text>();        
        gameOver.GetComponent<RectTransform>().SetParent(canvas.transform);
        gameOver.transform.position = new Vector3(gameX, gameY, 0);

        // score text
        var scoreObj = Instantiate(scoreFab);
        var scoreX = canvas.GetComponent<RectTransform>().position.x + 16;
        var scoreY = canvas.GetComponent<RectTransform>().position.y - 27;

        var score = scoreObj.GetComponent<Text>();
        score.text = "Score: " + score_; // will need to pass in score.
        score.GetComponent<RectTransform>().SetParent(canvas.transform);
        score.transform.position = new Vector3(scoreX, scoreY, 0);

        // return to start page button
        var returnTo = Instantiate(returnFab);
        var retX = canvas.GetComponent<RectTransform>().position.x -5;
        var retY = canvas.GetComponent<RectTransform>().position.y - 133;

        var returnButton = returnTo.GetComponent<Button>();
        returnButton.GetComponent<RectTransform>().SetParent(canvas.transform);
        returnButton.transform.position = new Vector3(retX, retY, 0);
        returnButton.onClick.AddListener(returnClicked);
    }
    void returnClicked()
    {
        Debug.Log("Return to Start Clicked");
        //return to start scene

        var gameManager = GameObject.FindObjectOfType<GmManager>();

        // destroy StartScene objects
        var startObjects = GameObject.FindGameObjectsWithTag("End");
        foreach (var obj in startObjects)
        {
            Destroy(obj);
        }

        // get random cryptogram to pass to game manager        
        gameManager.Start();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
