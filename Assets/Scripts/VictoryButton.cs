using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryButton : MonoBehaviour
{
    [SerializeField] private bool isPlayerCharacterNextToButton = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerCharacterNextToButton = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerCharacterNextToButton = false;
        }
    }
}
