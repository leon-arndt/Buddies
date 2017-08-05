using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ScoreManager : NetworkBehaviour {
    public TextScoreController myTextScoreController;
    Text myScoreText;
    
    [SyncVar(hook = "AddToScore")]
    public int score = 0;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddToScore(int summand) {
        score += summand;
        Debug.Log("The Score is now " + score);
        myTextScoreController.UpdateScoreUI(score);
    }

    public int GetScore() {
        return score;
    }
}
