using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParkourTutorialTrigger : MonoBehaviour
{
    [SerializeField] private Button tutorialButton; // Reference to the TutorialUI script

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Display the tutorial button
            tutorialButton.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Disable button
            tutorialButton.gameObject.SetActive(false);

        }
    }
}
