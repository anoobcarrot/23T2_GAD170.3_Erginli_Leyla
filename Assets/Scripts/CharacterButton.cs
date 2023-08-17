using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour
{
    [SerializeField] private string characterName; // Assign the character's name
    [SerializeField] private CharacterSelectionManager selectionManager;
    [SerializeField] private UIManager uiManager;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        selectionManager.SelectCharacter(characterName);
        uiManager.UpdateSelectedCharacterText(characterName); // Update the selected character text
    }
}
