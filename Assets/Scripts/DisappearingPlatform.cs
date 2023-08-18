using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    private MeshRenderer platformRenderer;
    private Collider platformCollider;

    private void Start()
    {
        platformRenderer = GetComponent<MeshRenderer>();
        platformCollider = GetComponent<Collider>();
        StartCoroutine(DisappearAndReappear());
    }

    private IEnumerator DisappearAndReappear()
    {
        while (true)
        {
            // Disappear
            platformRenderer.enabled = false;
            platformCollider.enabled = false;
            yield return new WaitForSeconds(3f);

            // Reappear
            platformRenderer.enabled = true;
            platformCollider.enabled = true;
            yield return new WaitForSeconds(2f);
        }
    }
}
