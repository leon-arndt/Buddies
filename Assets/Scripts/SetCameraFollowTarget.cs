using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is an unused script which was previously used to give the camera a new target to follow
/// </summary>
public class SetCameraFollowTarget : MonoBehaviour {
    void Start() {
        Camera.main.GetComponent<CameraFollow>().SetTarget(gameObject.transform);
    }
}   