using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


public class PlayerController : NetworkBehaviour { //changed to NetworkBehavior from MonoBehavior
    /// <summary>
    /// Welcome to Player Controller City.
    /// If you look to your left you'll see shooting and on your right you'll find respawning and health.
    /// This script does deceivingly little. A lot of the work is done by Unity and he High-Level Networking API.
    /// I initially encountered a lot of problems with local vs client in terms of camera and movement
    /// but these were eventually ironed out.
    /// 
    /// Note: The bullets shoot from a Cylinder (a child of the mesh) located on the player's chest.
    /// I played around a lot with using different models for the characters, such as the voxel characters
    /// but ended up liking the contrast of realistic and cartoony enough that I never replaced Ethan.
    /// </summary>
    
    //public float moveSpeed = 10f; //unused
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public GameObject myCam;
        
    public override void OnStartLocalPlayer() {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    private void Start() {
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
