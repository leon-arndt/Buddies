using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinGame : MonoBehaviour {//reverted to MonoBehaviour
    public GameObject WinText;
    
    private void Start() {
        Debug.Log("The Exit exists");
        WinText.SetActive(false);
        float startTime = Time.time;
    }
    public void OnCollisionEnter(Collision o) { //player reaches goal
        Debug.Log("A Player has Won");
        //SceneManager.LoadScene("GameOver");

        if (o.gameObject.tag == "PlayerObject") {
            //[Command]
            WinText.SetActive(true);
            Debug.Log("Win Scene should have loaded (Player Collision)");
            //SceneManager.LoadScene("GameOver");
            //NetworkManager.ServerChangeScene("GameOver");
            //NetworkClient.Ready()
        }
    }
}