using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingTutorialTrigger : MonoBehaviour
{
    [SerializeField] GameObject tutorial3DText; // Assign the 3D text tutorial prefab in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (tutorial3DText != null)
            {
                tutorial3DText.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (tutorial3DText != null)
            {
                tutorial3DText.SetActive(false);
            }
        }
    }
}
