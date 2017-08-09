using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
    /// <summary>
    /// This is the script which controls how the bullets behave.
    /// They started out from the Unity multiplayer FPS tutorial found on the documentation.
    /// The code here is very minimal because bullets don't need to do much.
    /// </summary>

    void OnCollisionEnter(Collision collision) {
        Debug.Log("bullet hits " + collision.transform.name);
        //check that hit is not the other player before continuing
        //...

        /* var hit = collision.gameObject;
         var health = hit.GetComponent<Health>();
         if (health != null) {
             health.TakeDamage(10);
         }
         */

        if (collision.gameObject.tag != "PlayerObject") { //does not hurt players
            Destroy(gameObject);
        }
    }
}