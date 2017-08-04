using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCameraFollowTarget : MonoBehaviour {
    void Start() {
        Camera.main.GetComponent<CameraFollow>().SetTarget(gameObject.transform);
    }
}   