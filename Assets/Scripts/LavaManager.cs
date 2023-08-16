using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaManager : MonoBehaviour
{
    private Vector3 initialPosition;

    private void Start()
    {
        // Store the initial position when the scene starts
        initialPosition = transform.position;
    }

    public void ResetPosition()
    {
        // Reset the lava's position to the initial position
        transform.position = initialPosition;
    }
}
