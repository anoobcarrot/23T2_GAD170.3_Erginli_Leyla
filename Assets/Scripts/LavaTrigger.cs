using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaTrigger : MonoBehaviour
{
    [SerializeField] private PlayerDeath[] playerDeaths; // Array of PlayerDeath scripts
    [SerializeField] private PlayerMovement[] playerMovements; // Array of PlayerMovement scripts

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (PlayerDeath playerDeath in playerDeaths)
            {
                playerDeath.Die();
            }

            foreach (PlayerMovement playerMovement in playerMovements)
            {
                Debug.Log("Disable Movement");
                playerMovement.DisableMovement();
            }
        }
    }
}