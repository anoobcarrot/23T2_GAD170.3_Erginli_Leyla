using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    [SerializeField] private AudioSource buttonAudioSource;

    public void Quit()
    {
        // Play the button click sound from the AudioSource
        buttonAudioSource.Play();

        // Quit the application after a short delay
        StartCoroutine(QuitWithDelay());
    }

    private IEnumerator QuitWithDelay()
    {
        // Wait for a short delay before quitting
        yield return new WaitForSeconds(0.5f); // Adjust the delay as needed

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}