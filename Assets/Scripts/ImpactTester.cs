using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactTester : MonoBehaviour
{
    // We want the script to hand COLLISION and TRIGGER detection!

    // First, collisions...

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Oopsie!");

        // Destroy the Ground
        Destroy(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Oopsie, ya yeet");
    }
    // Next, triggers...

}
