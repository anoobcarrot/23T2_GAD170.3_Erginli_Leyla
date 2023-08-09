using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class IceArea : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("YOU ARE IN THE ICE ZONE!");
        }
    }
