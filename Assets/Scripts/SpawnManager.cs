using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject lilBroPrefab; // Reference to the object you want to spawn
    [SerializeField] private Transform spawnPoint;   // Reference to the spawn point Transform

    private void Start()
    {
        // Call a method to spawn the object when needed
        SpawnObject();
    }

    private void SpawnObject()
    {
        Instantiate(lilBroPrefab, spawnPoint.position, spawnPoint.rotation);
    }
    public void RespawnPlayer(Transform playerTransform)
    {
        playerTransform.position = spawnPoint.position; // Set player's position to the spawn point
    }
}