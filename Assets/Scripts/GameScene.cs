using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{

    private void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void RestartScene()
    {

        // Go scene
        SceneManager.LoadScene("Game");
    }
}