using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatUIManager : MonoBehaviour
{
    [SerializeField] private Text levelText;
    [SerializeField] private Text experienceText;
    [SerializeField] private Text coinsText;
    [SerializeField] private Text balanceText;
    [SerializeField] private GameManager gameManager;

    private void UpdateUI()
    {
        levelText.text = "Level: " + GameManager.Instance.currentLevel;
        experienceText.text = "Experience: " + GameManager.Instance.currentExperience;
        coinsText.text = "Coins: " + GameManager.Instance.currentCoins;
        balanceText.text = "Balance: " + GameManager.Instance.currentCoins;
    }

    public void UpdateStatsUI()
    {
        UpdateUI();
    }

    public void MainMenuButtonClicked()
    {
        // Load the main menu scene
        SceneManager.LoadScene("Main Menu");
    }

    public void LevelSelectionButtonClicked()
    {
        // Load the level selection scene
        SceneManager.LoadScene("Level Selection");
    }
}

