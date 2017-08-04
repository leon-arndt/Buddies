using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlashAnimation : MonoBehaviour {
    public ParticleSystem particles;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Particles Spawned");
            particles.Play();
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            Debug.Log("Particles Killed");
            particles.Stop();
        }
    }
}
