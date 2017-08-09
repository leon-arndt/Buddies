using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {
    /// <summary>
    /// This health scripts is modelled after the Unity FPS Multiplayer tutorial on the documentation
    /// It works quite well but the way visuals are done is unflexible.
    /// The health script is used for the players.
    /// </summary>

    public RectTransform healthBar;

    public const int maxHealth = 100;
    [SyncVar(hook = "OnChangeHealth")]
    public int currentHealth = maxHealth;
    

    public void TakeDamage(int amount) {
        if (!isServer) {
            return;
        }

        currentHealth -= amount;    
        if (currentHealth <= 0) {
            Debug.Log("Health: Player has died");
            currentHealth = maxHealth; //reset player health
            var playerController = GetComponent<PlayerController>();
            playerController.RpcRespawn();

            AudioSource audio = GetComponent<AudioSource>(); //play death sound effect
            audio.Play();
        }

        //healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
    }
    void OnChangeHealth(int currentHealth) {
        healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
    }
}
