using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel; // Reference to the settings panel in the scene
    [SerializeField] private Slider volumeSlider;      // Reference to the volume slider UI element

    [SerializeField] private List<AudioSource> audioSources; // List of Audio Sources to control

    [SerializeField] private float delayBeforeTransition = 0.5f; // Adjust the delay as needed

    [SerializeField] private AudioSource buttonAudioSource;

    [SerializeField] private VolumeManager volumeManager;

    private void Start()
    {

        volumeSlider.onValueChanged.AddListener(OnVolumeSliderValueChanged);

        // Initialize the slider value based on current volume
        volumeSlider.value = audioSources[0].volume;

        // Subscribe to the slider value change event
        volumeSlider.onValueChanged.AddListener(OnVolumeSliderValueChanged);

        // Hide the settings panel initially
        settingsPanel.SetActive(false);
    }

    public void OpenSettings()
    {

    // Play the button click sound from the AudioSource
    buttonAudioSource.Play();

        // Start the delayed scene transition
        StartCoroutine(DelayOpenSettings());
}

private IEnumerator DelayOpenSettings()
{
    // Wait for the specified delay
    yield return new WaitForSeconds(delayBeforeTransition);

    // Show the settings panel
    settingsPanel.SetActive(true);
}

    public void CloseSettings()
    {
        /// Play the button click sound from the AudioSource
        buttonAudioSource.Play();

        // Start the delayed scene transition
        StartCoroutine(DelayCloseSettings());
    }

    private IEnumerator DelayCloseSettings()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayBeforeTransition);

        // Show the settings panel
        settingsPanel.SetActive(false);
    }

    public void OnVolumeSliderValueChanged(float volume)
    {
        // Update the volume of each audio source
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = volume;
            Debug.Log("Background Music Volume (After): " + audioSource.volume);
        }

        volumeManager.UpdateVolume(volume);
    }
}
