using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private RespawnButton respawnButton;
    [SerializeField] private LavaAndTutorial lavaAndTutorial;
    [SerializeField] private PlayerMovement[] playerMovements; // Array of PlayerMovement scripts
    [SerializeField] private ParticleSystem deathParticles;

    public void Die()
    {
        Debug.Log("Player Died!");

        lavaAndTutorial.isPlayerDead = true;

        // Disable movement for all player characters
        foreach (PlayerMovement playerMovement in playerMovements)
        {
            playerMovement.DisableMovement();
        }

        // Play the death particles
        if (deathParticles != null)
        {
            deathParticles.Play();
        }

        // Call the respawn method from the respawn script
        respawnButton.ShowButton(); // show respawn button
    }
}


