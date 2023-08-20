using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectionManager : MonoBehaviour
{
    [SerializeField] private string gameScene = "Game";
    [SerializeField] private UIManager uiManager;

    private string selectedCharacter;

    public void SelectCharacter(string characterName)
    {
        selectedCharacter = characterName;

        // Update the selected character text and show the start button
        uiManager.EnableStartButton();

        // Set the selected character in CharacterDataStorage
        CharacterDataStorage.SelectedCharacter = selectedCharacter;
    }

    public void StartGame()
    {
        if (!string.IsNullOrEmpty(selectedCharacter))
        {
            SceneManager.LoadScene(gameScene);
        }
        else
        {
            Debug.LogWarning("No character selected.");
        }
    }
}
