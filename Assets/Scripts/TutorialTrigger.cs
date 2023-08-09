using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialTrigger : MonoBehaviour
{
    // When the player character enters this zone,
    // Display the tutorial text

    [SerializeField] TextMeshPro tutorialText;

    private void OnTriggerEnter(Collider other)
    {
        // If the player character triggers this method
        if (other.CompareTag("Player"))
        {
            // Show tutorial text
            tutorialText.enabled = true;
        }
    }
}