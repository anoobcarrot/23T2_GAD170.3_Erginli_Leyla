using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] public int currentLevel = 1;
    [SerializeField] public int currentExperience = 0;
    [SerializeField] public int currentCoins = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void CompleteLevel(int experienceReward, int coinsReward)
    {
        currentExperience += experienceReward;
        currentCoins += coinsReward;

        if (currentExperience >= CalculateExperienceRequiredForNextLevel())
        {
            LevelUp();
        }

        SaveManager.SaveGameData();
    }

    private int CalculateExperienceRequiredForNextLevel()
    {
        return currentLevel * 100;
    }

    private void LevelUp()
    {
        currentLevel++;
    }
}
