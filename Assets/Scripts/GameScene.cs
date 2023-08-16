using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    private static GameScene Instance;

    private Vector3 initialLavaPosition;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Record initial lava position
        initialLavaPosition = GameObject.Find("Lava").transform.position;
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void RestartScene()
    {
        // Reset lava position
        GameObject.Find("Lava").transform.position = initialLavaPosition;

        // Restart the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}