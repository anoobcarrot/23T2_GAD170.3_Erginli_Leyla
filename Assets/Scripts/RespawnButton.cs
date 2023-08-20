using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RespawnButton : MonoBehaviour
{
    [SerializeField] private LavaAndTutorial lavaAndTutorial;
    [SerializeField] private PlayerDeath[] playerDeaths; // Array of PlayerDeath scripts
    [SerializeField] private PlayerMovement[] playerMovements; // Array of PlayerMovement scripts
    [SerializeField] private Button respawnButton;
    [SerializeField] private GameObject respawnImage;
    [SerializeField] private Text respawnText;
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private RespawnScene respawnScene;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();

        // remove the button
        respawnButton.gameObject.SetActive(false);

        // remove the respawn image
        respawnImage.SetActive(false);

        // remove the respawn text
        respawnText.gameObject.SetActive(false);
    }

    public void ShowButton()
    {
        // Check if the player is dead in the script
        if (lavaAndTutorial.isPlayerDead)
        {
            // Disable movement for all player characters
            foreach (PlayerMovement playerMovement in playerMovements)
            {
                playerMovement.DisableMovement();
            }

            // Show the respawn button, image, and text
            respawnButton.gameObject.SetActive(true);
            respawnImage.SetActive(true);
            respawnText.gameObject.SetActive(true);
        }
    }

    public void RespawnPlayer()
    {
        // Enable movement for all player characters after respawn
        foreach (PlayerMovement playerMovement in playerMovements)
        {
            playerMovement.SetAllowMovement(true);
        }

        // Hide the button, image, and text
        respawnButton.gameObject.SetActive(false);
        respawnImage.SetActive(false);
        respawnText.gameObject.SetActive(false);

        // Respawn the player characters and reset the lava's position
        lavaAndTutorial.isPlayerDead = false;
        lavaAndTutorial.ResetPosition();
        respawnScene.RestartScene();
    }

}
