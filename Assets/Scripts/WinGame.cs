using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinGame : MonoBehaviour {//reverted to MonoBehaviour
    /// <summary>
    /// This script is attached to a cube which efefctively marks the end of the level
    /// It tells the camera when it should start to pan out.
    /// It also puts text on the UI canvas to inform the players that the game has ended.
    /// </summary>
    
    public GameObject WinText;
    public GameObject myCam;
    
    private void Start() {
        Debug.Log("The Exit exists");
        WinText.SetActive(false);
        float startTime = Time.time;
    }
    public void OnCollisionEnter(Collision o) { //player reaches goal
        Debug.Log("A Player has Won");
        myCam.GetComponent<CameraFollow>().camZoomsOut = true;
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