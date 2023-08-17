using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text selectedCharacterText;
    [SerializeField] private GameObject startButton;

    private CharacterSelectionManager selectionManager;

    private void Start()
    {
        selectionManager = GetComponent<CharacterSelectionManager>();
        startButton.SetActive(false); // Hide the start button initially
    }

    public void UpdateSelectedCharacterText(string characterName)
    {
        selectedCharacterText.text = "You have chosen: " + characterName;
        startButton.SetActive(true); // Show the start button
    }
}