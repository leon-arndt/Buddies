using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    /// <summary>
    /// A clever little script I wrote which follows the local player.
    /// It only follows the player along one axis so that they can focus on the action.
    /// The camera zooms out at the end of the game (like in a cutscene).
    /// </summary>

    public Transform playerTransform; //always gets the same player, use an array instead
    public GameObject ZoomTo;

    public bool camZoomsOut = false; //is the camera zooming out at the end of the game.
    public int depth = 8; //how far the camera should remain behind the player
    public int height = 10; //y component


    // Update is called once per frame
    void Update() {
        if (camZoomsOut) { //zooming out at the end of the game
            transform.position = Vector3.Lerp(transform.position, ZoomTo.transform.position, 0.05f);
        } else { //following the player
            if (playerTransform != null) {
                transform.position = new Vector3(playerTransform.position.x - depth, height, 0);
                //Debug.Log("The player I'm following seems to be at" + playerTransform.position);
            }
        }
    }

    public void SetTarget(Transform target) { //manually set a new target for the camera
        playerTransform = target;
    }
}
