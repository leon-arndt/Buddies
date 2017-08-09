using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using C; //needed for Tags
using UnityEngine.UI;

public class TextScoreController : MonoBehaviour {
    /// <summary>
    /// This is the visual side of the Score Manager.
    /// It updates the UI element as the score increases.
    /// 
    /// </summary>
    
    //public ScoreManager myScoreManager;
    Text myText;

    void Start() {
        //GameObject myScoreManager = GameObject.Find("ScoreManager");
        Text myText= gameObject.GetComponent<Text>();
        myText.text = "0";
    }

    public void UpdateScoreUI(int newScore) { //bad because it calls every frame, could use optimization
        Text myText = gameObject.GetComponent<Text>();
        myText.text = newScore.ToString(); //myScoreManager.GetComponent<ScoreManager>().GetScore().ToString(); //not set to an instance of an object, doesn't remember from Start()

    }
}