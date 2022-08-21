using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GmManager : MonoBehaviour
{
    // scene prefabs
    public GameObject start, theme, difficulty, end;                                                              //TODO: create prefab for main
    [HideInInspector]
    public GameObject scene;
    [HideInInspector]
    public string text;

    // Start is called before the first frame update
    public void Start()
    {
        // instantiate the start scene
        var canvas = GameObject.Find("Canvas");
        var cryptogram = canvas.transform.Find("Cryptogram").gameObject;
        cryptogram.SetActive(true);

        scene = Instantiate(start);
        
    }

    // call from the Theme Button to instantiate the theme scene.
    public void goToTheme()
    {
        Debug.Log("Going to Theme page");       
       
        scene = Instantiate(theme);
       
    }

    // call from the either the Random or Themed buttons 
    public void receivedLevel(string rec_text)
    {
        Debug.Log("Received cryptogram: " + text);
        //TODO: in main scene script, add fcn to take in script to further use when building the input fields OR wall of text.

        text = rec_text;
        scene = Instantiate(difficulty);
    }

    // called from menu
    public void goToDifficulty()
    {
        scene = Instantiate(difficulty);
    }

    // call from difficulty scene
    public void receivedDifficulty()
    {
        // Call wallof text to initialize cryptogram for received text
        var wallOfText = GameObject.FindObjectOfType<WallOfTextScript>();
        wallOfText.Initialize(text);
    }

    // call from wall of text
    public void gameEnd(int score)
    {
        //TODO: add score param

        //EndScene end_ = GameObject.FindObjectOfType<GmManager>().FindObjectOfType<EndScene>() as EndScene;
        EndScene.setScore(score);
    
        scene = Instantiate(end);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
