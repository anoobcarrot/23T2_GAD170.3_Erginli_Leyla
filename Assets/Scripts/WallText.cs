using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallText : MonoBehaviour
{
    [SerializeField] private GameObject button; // Reference to the button GameObject
    [SerializeField] private GameObject textToShow; // Reference to the 3D Text GameObject

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger!");
            textToShow.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited trigger!");
            textToShow.SetActive(false);
        }
    }
}





