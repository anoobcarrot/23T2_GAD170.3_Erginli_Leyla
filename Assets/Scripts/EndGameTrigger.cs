using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameTrigger : MonoBehaviour
{
    [SerializeField] private GameObject escapeText; // Reference to the "Left click to escape" text
    [SerializeField] private Text winText; // Reference to the "You have won" text
    [SerializeField] private Button returnButton; // Reference to the return to main menu button
    [SerializeField] private GameObject winImage;
    [SerializeField] private Button menuButton; // Reference to Main Menu Button already on screen
    [SerializeField] private Button tutorialButton; // Reference to the Tutorial Button already on screen

    [SerializeField] private AudioSource buttonAudioSource;

    [SerializeField] private string nextSceneName;
    [SerializeField] private float delayBeforeTransition = 0.5f; // Adjust the delay as needed

    private bool gameWon = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !gameWon)
        {
            escapeText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            escapeText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!gameWon && escapeText.gameObject.activeSelf && Input.GetMouseButtonDown(0)) // 0 represents the left mouse button
            {
                WinGame();
            }
        }
    }

    private void WinGame()
    {
        gameWon = true;
        tutorialButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
        escapeText.gameObject.SetActive(false);
        winText.gameObject.SetActive(true);
        winImage.gameObject.SetActive(true);
        returnButton.gameObject.SetActive(true);
    }

    public void ReturnToMainMenu()
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