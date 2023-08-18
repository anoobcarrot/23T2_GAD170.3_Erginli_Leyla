using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private Text tutorialText; // Reference to the tutorial text UI element
    [SerializeField] private GameObject tutorialImage;
    [SerializeField] private Button okButton; // Reference to the OK button UI element

    private void Start()
    {
        // Hide the tutorial UI initially
        tutorialText.gameObject.SetActive(false);
        tutorialImage.SetActive(false);
        okButton.gameObject.SetActive(false);

        // Set up button click event
        okButton.onClick.AddListener(OnOkButtonClicked);
    }

    public void ShowTutorial(string text)
    {
        // Show the tutorial UI
        tutorialText.gameObject.SetActive(true);
        tutorialImage.SetActive(true);
        okButton.gameObject.SetActive(true);

    }

    private void HideTutorial()
    {
        // Hide the tutorial UI
        tutorialText.gameObject.SetActive(false);
        okButton.gameObject.SetActive(false);
        tutorialImage.SetActive(false);
    }

    public void OnOkButtonClicked()
    {
        // Continue with the parkour 
        HideTutorial();
    }
}
