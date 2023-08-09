using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject lilBroPrefab; // Reference to the object you want to spawn
        [SerializeField] private GameObject spawnPoint;   // Reference to the spawn point GameObject

        private void Start()
        {
            // Call a method to spawn the object when needed
            SpawnObject();
        }

        private void SpawnObject()
        {
            Instantiate(lilBroPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
    }