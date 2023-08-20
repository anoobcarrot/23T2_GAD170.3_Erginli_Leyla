using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectionScene : MonoBehaviour
{
    [SerializeField] private string nextSceneName;
    [SerializeField] private float delayBeforeTransition = 0.5f; // Adjust the delay as needed

    [SerializeField] private AudioSource buttonAudioSource;

    public void OnButtonClick()
    {
        // Play the button click sound from the AudioSource
        buttonAudioSource.Play();

        // Start the delayed scene transition
        StartCoroutine(DelayedSceneTransition());
    }

    private IEnumerator DelayedSceneTransition()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayBeforeTransition);

        // Transition to the next scene
        SceneManager.LoadScene(nextSceneName);
    }
}






