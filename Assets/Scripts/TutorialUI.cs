using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private GameObject tutorialBase;
    [SerializeField] private Button exitButton; // Reference to the exit button UI element
    [SerializeField] private float delayBeforeTransition = 0.5f; // Adjust the delay as needed
    [SerializeField] private AudioSource buttonAudioSource;

    private void Start()
    {
        // Hide the tutorial UI initially
        tutorialBase.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
    }

    public void ShowTutorial(string text)
    {

        // Play the button click sound from the AudioSource
        buttonAudioSource.Play();

        // Start the delayed scene transition
        StartCoroutine(DelayShowTutorial());
    }

    private IEnumerator DelayShowTutorial()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayBeforeTransition);

        // Show the tutorial UI
        tutorialBase.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

    public void CloseTutorial()
    {
        /// Play the button click sound from the AudioSource
        buttonAudioSource.Play();

        // Start the delayed scene transition
        StartCoroutine(DelayCloseTutorial());
    }

    private IEnumerator DelayCloseTutorial()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayBeforeTransition);

        // Hide the tutorial UI
        tutorialBase.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
    }
}
