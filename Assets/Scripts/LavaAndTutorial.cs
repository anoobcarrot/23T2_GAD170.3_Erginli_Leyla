using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class LavaAndTutorial : MonoBehaviour
{
    [SerializeField] private float riseSpeed = 1.0f;      // Speed at which the lava rises
    [SerializeField] private float riseDelay = 30.0f;     // Delay before the lava starts rising
    [SerializeField] private float riseInterval = 5.0f;   // Interval at which the lava rises
    [SerializeField] private Text timerText; // UI lava timer countdown
    [SerializeField] private Text countdownText;
    [SerializeField] private Text goText;
    [SerializeField] private Text lavaText;
    [SerializeField] private GameObject tutorialUI;
    [SerializeField] private Button tutorialButton;
    [SerializeField] private GameObject spawnBlocker;
    [SerializeField] private TutorialTrigger tutorialTrigger;
    [SerializeField] private PlayerMovement[] playerMovements;
    [SerializeField] private Button respawnButton;
    [SerializeField] private GameObject respawnImage;
    [SerializeField] private Text respawnText;
    [SerializeField] private Vector3 initialPosition;
    [SerializeField] private int timesToRise = 0;
    [SerializeField] private AudioSource backgroundMusicAudioSource; // Reference to the background Audio Source component
    [SerializeField] private AudioSource countdownAudioSource; // Reference to the countdown Audio Source component

    [SerializeField] private float delayBeforeTransition = 0.5f; // Adjust the delay as needed
    [SerializeField] private AudioSource buttonAudioSource;

    public bool isPlayerDead = false;
    private bool playerEnteredTrigger = false;
    [SerializeField] private bool shouldRise = false;
    [SerializeField] private bool notDelayed = false;
    private float previousRiseTime = 0.0f;
    private float startTime;
    [SerializeField] private Vector3 initialScale;

    private void Start()
    {
        PlayerPrefs.DeleteKey("TutorialShown");
        tutorialUI.gameObject.SetActive(false);
        startTime = Time.time;
        tutorialTrigger.onPlayerEnterTrigger.AddListener(ShowTutorial);
        shouldRise = false;
        notDelayed = false;
        // Store the initial position when the scene starts
        initialPosition = transform.position;
        initialScale = transform.localScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerEnteredTrigger = true;

            // Show the tutorial
            ShowTutorial();
        }
    }

    private void ShowTutorial()
    {
        // Check if the tutorial has already been shown
        if (!PlayerPrefs.HasKey("TutorialShown"))
        {
            // Show the tutorial UI
            tutorialUI.gameObject.SetActive(true);

            tutorialButton.onClick.AddListener(StartGameButtonClicked); // Listen to the button click event

            // Set the PlayerPrefs variable to remember the tutorial has been shown
            PlayerPrefs.SetInt("TutorialShown", 1);
        }
        else
        {
            // Hide the tutorial text, image, button and title
            tutorialUI.gameObject.SetActive(false);
        }
    }

    private void StartGameButtonClicked()
    {
        // Play the button click sound from the AudioSource
        buttonAudioSource.Play();

        // Start the delayed scene transition
        StartCoroutine(DelayCloseTutorial());
    }

    private IEnumerator DelayCloseTutorial()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayBeforeTransition);

        // Hide the tutorial UI
        tutorialUI.gameObject.SetActive(false);

        // Start the StartGame coroutine
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(0.1f);

        StartCoroutine(CountdownSequence());
        StartCoroutine(StartRisingDelayed());
        shouldRise = false;
        notDelayed = false;
        ResetPosition();
        // Reset timesToRise
        timesToRise = 0;
    }

    private IEnumerator CountdownSequence()
    {
        timerText.gameObject.SetActive(false);
        countdownText.gameObject.SetActive(true);
        countdownText.text = "3";

        if (countdownAudioSource != null)
        {
            countdownAudioSource.Play();
            yield return new WaitForSeconds(1.0f);
        }

        countdownText.text = "2";
        yield return new WaitForSeconds(1.0f);

        countdownText.text = "1";
        yield return new WaitForSeconds(1.0f);

        countdownText.gameObject.SetActive(false);
        goText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.0f);

        goText.gameObject.SetActive(false);
        timerText.gameObject.SetActive(true);

        // Check if the background music Audio Source is assigned
        if (backgroundMusicAudioSource != null)
        {
            backgroundMusicAudioSource.Play(); // Play the background music
        }
        else
        {
            Debug.LogError("Background Music Audio Source is not assigned!");
        }

        spawnBlocker.gameObject.SetActive(false);
        startTime = Time.time;
        yield return new WaitForSeconds(30.0f);
        ResetPosition();
        shouldRise = true;
        notDelayed = true;


    }

    private void Update()
    {
        if (playerEnteredTrigger)
        {
            ShowTutorial();
            playerEnteredTrigger = false; // Reset the flag to prevent showing the tutorial repeatedly
        }
        else
        {
            UpdateTimerText();
            float elapsedTime = Time.time - startTime;
            float distanceToRise = (elapsedTime / riseInterval) * riseSpeed;

            if (notDelayed)
            {
                // Calculate how many times to rise since the last rise
                timesToRise = Mathf.FloorToInt((Time.time - previousRiseTime) / riseInterval);
           
            }
            if (shouldRise)
            {
                // Calculate how many times to rise since the start of the game
                int timesToRise = Mathf.FloorToInt(elapsedTime / riseInterval);

                // Update lava's position by changing its Y scale
                Vector3 newScale = new Vector3(transform.localScale.x, initialScale.y + timesToRise, transform.localScale.z);
                transform.localScale = newScale;

                // OLD SCRIPT DONT NEED, SAVED JUST IN CASE
                // if (shouldRise)
                //if (timesToRise > 0)
           // {
                // Update lava's position
               // transform.position = new Vector3(transform.position.x, transform.position.y + timesToRise, transform.position.z);

                // Update previous rise time
              //  previousRiseTime = Time.time;
            }
        }
    }

        private void UpdateTimerText()
    {
        float elapsedTime = Time.time - startTime;
        float remainingTime = Mathf.Max(0f, riseDelay - elapsedTime);
        int seconds = Mathf.FloorToInt(remainingTime);
        timerText.text = "Time until lava: " + seconds.ToString();
    }

    private IEnumerator StartRisingDelayed()
    {
        StartRising();
        yield return new WaitForSeconds(riseDelay);
        shouldRise = true;
        StartCoroutine(RiseEveryInterval());
        yield return new WaitForSeconds(4.0f);
        timerText.gameObject.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        lavaText.gameObject.SetActive(true);
    }

    private IEnumerator RiseEveryInterval()
    {
        if (shouldRise)
        {
            yield return new WaitForSeconds(riseInterval);
            transform.position = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
        }
    }

    private void StartRising()
    {
        shouldRise = true;
    }
    public void ResetPosition()
    {
        // Reset the lava's position to the initial position
        transform.position = initialPosition;

        // Reset timesToRise
        timesToRise = 0;
    }
}