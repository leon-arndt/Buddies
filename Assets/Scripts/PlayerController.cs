using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


public class PlayerController : NetworkBehaviour { //changed to NetworkBehavior from MonoBehavior
    //public float moveSpeed = 10f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public GameObject myCam;
    //public Rigidbody rb;
        
    public override void OnStartLocalPlayer() {
        GetComponent<MeshRenderer>().material.color = Color.blue;
        //Instantiate(myCam, new Vector3(-10.6f, 6.25f, 0), Quaternion.identity);
        //myCam.GetComponent<CameraFollow>().SetTarget(gameObject.transform);
        if (isLocalPlayer) {
            //Camera.main.GetComponent<CameraFollow>().SetTarget(gameObject.transform);
        }
        //Debug.Log("Hi I'm a local player!"); //is never called
    }

    /*private void Start() { //remove this if it causes problems, called by both players later by the client so follows client
        Camera.main.GetComponent<CameraFollow>().SetTarget(gameObject.transform);
        rb = GetComponent<Rigidbody>();
    }*/


    private void Start() { //called by both?
        Debug.Log("Hi I'm a player");

        if (isLocalPlayer) {
            Debug.Log("I'm even a local player");
            Camera.main.GetComponent<CameraFollow>().SetTarget(gameObject.transform);
        }
    }

    void Update() {
        if (!isLocalPlayer) { //return if not called by the local player
            return;
        }



        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            CmdFire();
        }
    }

    public void OnCollisionEnter(Collision o) { //Collision Detection
        if (o.gameObject.tag == "Enemy") { //If the player is hit by an enemy
            Debug.Log("Player: Player hurt by enemy");
            var health = GetComponent<Health>();
            if (health != null) {
                health.TakeDamage(10);
                //AudioSource audio = GetComponent<AudioSource>(); //play a player hurt sound
                //audio.Play();
            }

                /*life--;
                rb.AddForce(transform.forward * -50.0f);
                if (life <= 0) {
                    Debug.Log("The Player has died");
                    //Destroy(gameObject);

                    RpcRespawn(); // called on the Server, but invoked on the Clients
                }*/

            }
    }


    [Command]
    void CmdFire() {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 12;

        // Spawn the bullet on the Clients
        NetworkServer.Spawn(bullet);

        // Destroy the bullet after 5 seconds
        Destroy(bullet, 5.0f);
    }

    [ClientRpc]
    public void RpcRespawn() {
        if (isLocalPlayer) {
            // move back to zero location
            transform.position = Vector3.zero;
        }
    }
}
