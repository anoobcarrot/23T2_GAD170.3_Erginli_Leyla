using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RespawnScene : MonoBehaviour
{
    [SerializeField] private float delayBeforeTransition = 0.5f; // Adjust the delay as needed

    [SerializeField] private AudioSource buttonAudioSource;

    public void RestartScene()
    {
        // Play the button click sound from the AudioSource
        buttonAudioSource.Play();

        // Start the delayed scene transition
        StartCoroutine(DelayRestartScene());
    }

    private IEnumerator DelayRestartScene()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayBeforeTransition);

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
