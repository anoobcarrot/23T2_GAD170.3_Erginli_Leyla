using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource[] audioSources;

    private void Start()
    {
        // Load the saved volume setting, defaulting to 1.0 (full volume)
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1.0f);
        volumeSlider.value = savedVolume;

        // Set the initial volume for all audio sources
        UpdateVolume(savedVolume);
    }

    public void UpdateVolume(float volume)
    {
        foreach (var audioSource in audioSources)
        {
            audioSource.volume = volume;
        }

        // Save the current volume setting
        PlayerPrefs.SetFloat("Volume", volume);
    }
}