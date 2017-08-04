using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public Transform playerTransform; //always gets the same player, use an array instead
    public int depth = 8;
    public int height = 10; //y component


    // Update is called once per frame
    void Update() {
        if (playerTransform != null) {
            transform.position = new Vector3(playerTransform.position.x - depth, height, 0);
            //Debug.Log("The player I'm following seems to be at" + playerTransform.position);
        }
    }

    public void SetTarget(Transform target) {
        playerTransform = target;
    }
}
