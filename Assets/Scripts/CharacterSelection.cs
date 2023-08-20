using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private List<GameObject> characterModels;
    [SerializeField] private List<RenderTexture> characterRenderTextures;
    [SerializeField] private List<Camera> characterCameras;
    [SerializeField] private RawImage characterImage;
    [SerializeField] private UIManager uiManager; // Reference to the UIManager script
    private int currentCharacterIndex = 0;

    [SerializeField] private Button rightButton;
    [SerializeField] private Button leftButton;
    [SerializeField] private AudioSource buttonAudioSource;

    private void Start()
    {
        SetCharacterModel(currentCharacterIndex);
        UpdateSelectedCharacterAndShowStartButton();
        rightButton.onClick.AddListener(SwitchToNextCharacter);
        leftButton.onClick.AddListener(SwitchToPreviousCharacter);
    }

    public void SwitchToPreviousCharacter()
    {
        // Play the button click sound from the AudioSource
        buttonAudioSource.Play();
        SwitchCharacter(-1);
    }

    public void SwitchToNextCharacter()
    {
        // Play the button click sound from the AudioSource
        buttonAudioSource.Play();
        SwitchCharacter(1);
    }

    private void SwitchCharacter(int direction)
    {
        currentCharacterIndex = (currentCharacterIndex + direction + characterModels.Count) % characterModels.Count;
        SetCharacterModel(currentCharacterIndex);

        UpdateSelectedCharacterAndShowStartButton();
    }

    private void SetCharacterModel(int index)
    {
        for (int i = 0; i < characterModels.Count; i++)
        {
            characterModels[i].SetActive(i == index);
            characterCameras[i].enabled = (i == index);
        }
        characterImage.texture = characterRenderTextures[index];
    }

    private void UpdateSelectedCharacterAndShowStartButton()
    {
        string characterName = characterModels[currentCharacterIndex].name;
        uiManager.UpdateSelectedCharacterText(characterName);
        uiManager.EnableStartButton();

        // Set the selected character in CharacterDataStorage
        CharacterDataStorage.SelectedCharacter = characterName;
    }
}