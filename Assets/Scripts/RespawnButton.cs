using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RespawnButton : MonoBehaviour
{
    [SerializeField] private LavaAndTutorial lavaAndTutorial;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Button respawnButton;
    [SerializeField] private GameObject respawnImage;
    [SerializeField] private Text respawnText;
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private PlayerDeath playerDeath;
    [SerializeField] private GameScene gameScene;

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
            respawnButton.gameObject.SetActive(true);

            // Show the respawn image
            respawnImage.SetActive(true);

            // Show the respawn text
            respawnText.gameObject.SetActive(true);
        }
    }

    public void RespawnPlayer()
    {
        // remove the button
        respawnButton.gameObject.SetActive(false);

        // remove the respawn image
        respawnImage.SetActive(false);

        // remove the respawn text
        respawnText.gameObject.SetActive(false);

        lavaAndTutorial.isPlayerDead = false;
        lavaAndTutorial.ResetPosition(); // Reset the lava's position
        gameScene.RestartScene();

    }
}