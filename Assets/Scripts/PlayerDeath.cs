using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private RespawnButton respawnButton;
    [SerializeField] private LavaAndTutorial lavaAndTutorial;

    public void Die()
    {
        Debug.Log("Player Died!");

        lavaAndTutorial.isPlayerDead = true;

        // // Disable player controls
         PlayerController playerController = GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.enabled = false;
        }

        // Call the respawn method from the respawn script
        respawnButton.ShowButton(); // show respawn button
    }
}


