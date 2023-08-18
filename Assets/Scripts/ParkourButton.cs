using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParkourButton : MonoBehaviour
{
    [SerializeField] private GameObject wall; // Reference to the wall GameObject

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Check for right mouse button click
            if (Input.GetMouseButtonDown(1)) // 1 represents the right mouse button
            {
                // Disable (hide) the wall
                wall.SetActive(false);
            }
        }
    }
}