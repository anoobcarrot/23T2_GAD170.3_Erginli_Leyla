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
    [SerializeField] private Text tutorialText; // Reference to the tutorial text UI element
    [SerializeField] private Button tutorialButton; // Reference to the button UI element
    [SerializeField] private GameObject tutorialImage;
    [SerializeField] private GameObject spawnBlocker;
    [SerializeField] private TutorialTrigger tutorialTrigger;

    private bool playerEnteredTrigger = false;
    private bool shouldRise = false;
    private bool hasDelayed = false;
    private float previousRiseTime = 0.0f;
    private float startTime;

    private void Start()
    {
        PlayerPrefs.DeleteKey("TutorialShown");
        tutorialText.gameObject.SetActive(false);
        tutorialImage.SetActive(false);
        tutorialButton.gameObject.SetActive(false);
        startTime = Time.time;
        tutorialTrigger.onPlayerEnterTrigger.AddListener(ShowTutorial);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerEnteredTrigger = true;
        }
    }

            private void ShowTutorial()
    {
        // Check if the tutorial has already been shown
        if (!PlayerPrefs.HasKey("TutorialShown"))
        { 
            // Show the tutorial text
            tutorialText.gameObject.SetActive(true);

        // Show the tutorial image
        tutorialImage.SetActive(true);

        // Show the button
        tutorialButton.gameObject.SetActive(true);

        tutorialButton.onClick.AddListener(StartGame); // Listen to the button click event
        tutorialButton.onClick.AddListener(HideTutorialImage); // Listen to the button click event

        // Set the PlayerPrefs variable to remember the tutorial has been shown
        PlayerPrefs.SetInt("TutorialShown", 1);
        }
        else
        {
            // Hide the tutorial text, image, and button
            tutorialText.gameObject.SetActive(false);
            tutorialImage.SetActive(false);
            tutorialButton.gameObject.SetActive(false);
        }
    }

    private void HideTutorialImage()
    {
        tutorialImage.SetActive(false); // Hide the tutorial image
        StartGame(); // Proceed to the countdown and game
    }

    private void StartGame()
    {
        tutorialText.gameObject.SetActive(false);
        tutorialButton.gameObject.SetActive(false);
        StartCoroutine(CountdownSequence());
        StartCoroutine(StartRisingDelayed());
    }

    private IEnumerator CountdownSequence()
    {
        timerText.gameObject.SetActive(false);
        countdownText.gameObject.SetActive(true);
        countdownText.text = "3";
        yield return new WaitForSeconds(1.0f);

        countdownText.text = "2";
        yield return new WaitForSeconds(1.0f);

        countdownText.text = "1";
        yield return new WaitForSeconds(1.0f);

        countdownText.gameObject.SetActive(false);
        goText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.0f);

        goText.gameObject.SetActive(false);
        timerText.gameObject.SetActive(true);

        spawnBlocker.gameObject.SetActive(false);
        startTime = Time.time;
    }

    private void Update()
    {
        if (playerEnteredTrigger)
        {
            ShowTutorial();
            playerEnteredTrigger = false; // Reset the flag to prevent showing the tutorial repeatedly
        }
        if (shouldRise)
        {
            UpdateTimerText();
            float elapsedTime = Time.time - startTime;
            float distanceToRise = (elapsedTime / riseInterval) * riseSpeed;

            // Calculate how many times to rise since the last rise
            int timesToRise = Mathf.FloorToInt((Time.time - previousRiseTime) / riseInterval);

            if (timesToRise > 0)
            {
                // Update lava's position
                transform.position = new Vector3(transform.position.x, transform.position.y + timesToRise, transform.position.z);

                // Update previous rise time
                previousRiseTime = Time.time;
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
        while (true)
        {
            yield return new WaitForSeconds(riseInterval);
            transform.position = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
        }
    }

    private void StartRising()
    {
        shouldRise = true;
    }
}