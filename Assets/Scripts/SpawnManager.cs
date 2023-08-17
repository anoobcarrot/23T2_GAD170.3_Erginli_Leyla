using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint; // Reference to the spawn point Transform

    [SerializeField] private GameObject penguinPrefab; // Reference to the Penguin prefab
    [SerializeField] private GameObject catPrefab;     // Reference to the Cat prefab
    [SerializeField] private GameObject chickenPrefab; // Reference to the Chicken prefab

    private GameObject spawnedCharacter; // Reference to the spawned character object

    private void Start()
    {
        // Call a method to spawn the object when needed
        SpawnSelectedCharacter();
    }

    private void SpawnSelectedCharacter()
    {
        string selectedCharacter = CharacterDataStorage.SelectedCharacter; // Retrieve the selected character name

        // based on the player's selected character, choose the appropriate prefab
        GameObject characterPrefab = GetCharacterPrefab(selectedCharacter);

        if (characterPrefab != null)
        {
            // Hide the previously spawned character if it exists
            if (spawnedCharacter != null)
            {
                Destroy(spawnedCharacter); // Destroy the previous instance
            }

            // Instantiate a new clone of the character prefab
            spawnedCharacter = Instantiate(characterPrefab, spawnPoint.position, spawnPoint.rotation);
            spawnedCharacter.SetActive(true); // Make sure the character is active

            // Activate the camera associated with the spawned character
            ActivateCharacterCamera(characterPrefab.name);
        }
        else
        {
            Debug.LogWarning("Selected character prefab not found.");
        }
    }

    private void ActivateCharacterCamera(string characterName)
    {
        // Activate the camera associated with the spawned character
        GameObject characterCamera = GameObject.Find(characterName + "Camera"); // Adjust the camera naming
        if (characterCamera != null)
        {
            characterCamera.SetActive(true);
        }
    }

    private GameObject GetCharacterPrefab(string characterName)
    {

        // dictionary mapping character names to prefabs
        Dictionary<string, GameObject> characterPrefabMap = new Dictionary<string, GameObject>
        {
            { "Penguin", penguinPrefab },
            { "Cat", catPrefab },
            { "Chicken", chickenPrefab }
        };

        // Retrieve the prefab based on the character name
        if (characterPrefabMap.TryGetValue(characterName, out GameObject characterPrefab))
        {
            return characterPrefab;
        }
        else
        {
            return null; // Character not found in the map
        }
    }

    public void RespawnPlayer(Transform playerTransform)
    {
        playerTransform.position = spawnPoint.position; // Set player's position to the spawn point
    }
}