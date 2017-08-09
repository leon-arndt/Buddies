using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesAutoDestroyer : MonoBehaviour {
    /// <summary>
    /// A super simple script to destroy particle systems after they have finished playing.
    /// This was necessary because otherwise the scene would be flooded with unneeded game objects.
    /// </summary>

    public ParticleSystem ps;

 
     void Start() {
        ps = GetComponent<ParticleSystem>(); //the particle system attached to the game object
     }

    void Update() {
        if (ps) {
            if (!ps.IsAlive()) { //has the animation finished playing?
                Destroy(gameObject);
            }
        }
    }
}
