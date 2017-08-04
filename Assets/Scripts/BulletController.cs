using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
    void OnCollisionEnter(Collision collision) { //might need to be onTriggerEnter,
        Debug.Log("bullet hits " + collision.transform.name);
        //check that hit is not the other player before continuing
        //...

        /* var hit = collision.gameObject;
         var health = hit.GetComponent<Health>();
         if (health != null) {
             health.TakeDamage(10);
         }
         */

        if (collision.gameObject.tag != "PlayerObject") {
            Destroy(gameObject);
        }
    }
}