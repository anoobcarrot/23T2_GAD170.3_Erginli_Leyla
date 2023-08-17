using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScene : MonoBehaviour
{
    [SerializeField] private CharacterSelectionManager selectionManager;

    [SerializeField] private Button startButton;

    public void StartGame()
    {
        selectionManager.StartGame(); // Call the StartGame method from the CharacterSelectionManager
    }

public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void RestartScene()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}