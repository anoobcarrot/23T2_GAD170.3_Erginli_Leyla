using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class TutorialTrigger : MonoBehaviour
{
    [SerializeField] private GameObject tutorialText;
    [SerializeField] private GameObject tutorialImage;
    [SerializeField] private GameObject tutorialButton;

    public UnityEvent onPlayerEnterTrigger;

private bool tutorialShown = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!tutorialShown && other.CompareTag("Player"))
        {
            tutorialShown = true;
            onPlayerEnterTrigger.Invoke(); // Raise the event when the player enters the trigger
        }
    }
}
   


