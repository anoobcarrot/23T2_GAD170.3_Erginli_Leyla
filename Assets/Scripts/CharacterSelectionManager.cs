using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectionManager : MonoBehaviour
{
    [SerializeField] private string gameScene = "Game"; // game scene
    [SerializeField] private List<CharacterButton> characterButtons; // list to store character buttons

    private string selectedCharacter;

    public void SelectCharacter(string characterName)
    {
        selectedCharacter = characterName;
    }

    public void StartGame()
    {
        if (!string.IsNullOrEmpty(selectedCharacter))
        {
            // Store the selected character data
            CharacterDataStorage.SelectedCharacter = selectedCharacter;

            // Load the game scene
            SceneManager.LoadScene(gameScene);
        }
        else
        {
            Debug.LogWarning("No character selected.");
        }
    }
}
