using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text selectedCharacterText;
    [SerializeField] private GameObject startButton;

    private void Start()
    {
        startButton.SetActive(true);
    }

    public void UpdateSelectedCharacterText(string characterName)
    {
        selectedCharacterText.text = "You have chosen: " + characterName;
    }

    public void EnableStartButton()
    {
        startButton.SetActive(true);
    }

    public void StartGame()
    {
        CharacterSelectionManager selectionManager = GetComponent<CharacterSelectionManager>();
        selectionManager.StartGame(); // Call the StartGame method from the CharacterSelectionManager
    }
}