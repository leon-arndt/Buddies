using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ScoreManager : NetworkBehaviour {
    /// <summary>
    /// This is a basic score manager I wrote which takes care of increasing the local score.
    /// It was original intended to be synced over the network but I was unable to achieve this.
    /// For now, enemy deaths points are earned locally and portal destruction awards both players.
    /// </summary>

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
