using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;
    private CharacterController characterController;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Input controls for movement (e.g., "Horizontal" and "Vertical").
        float moveSpeed = Mathf.Sqrt(characterController.velocity.sqrMagnitude);

        // Set parameters in the Animator to control the transitions between animations.
        animator.SetFloat("MoveSpeed", moveSpeed);

        // You can also set other parameters if needed, like "isRunning" or "isJumping."
        // animator.SetBool("isRunning", isRunning);
        // animator.SetBool("isJumping", isJumping);
    }
}






