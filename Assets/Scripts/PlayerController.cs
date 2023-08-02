using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5.0f;
    public float runSpeed = 10.0f;
    public float jumpForce = 8.0f;
    public float turnSmoothTime = 0.1f;
    public float speedSmoothTime = 0.1f;
    public float lookSpeed = 2.0f; // Speed of the camera rotation with the mouse.
    public float gravity = 9.81f; // Adjust the value to control the gravity force.

    public Transform playerCamera; // Assign your player camera to this variable in the Inspector.
    public Transform cameraLookAtPoint; // A point to look at while rotating the camera around the player (can be an empty GameObject).

    private Animator animator;
    private CharacterController characterController;
    private float turnSmoothVelocity;
    private float speedSmoothVelocity;
    private float currentSpeed;
    private float rotationX = 0.0f; // Current X-axis rotation of the camera.

    private bool isGrounded;

    private void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Check if the character is grounded
        isGrounded = characterController.isGrounded;

        // Handle falling if not grounded
        if (!isGrounded)
        {
            // Apply gravity to make the character fall
            characterController.Move(Vector3.down * gravity * Time.deltaTime);
        }

        // Get input axes
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Check if the character is moving or not
        bool isMoving = vertical != 0f || horizontal != 0f;

        // Calculate target rotation based on camera orientation
        float targetRotation = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;
        float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);

        // Rotate the character towards the calculated target rotation
        transform.rotation = Quaternion.Euler(0f, rotation, 0f);

        // Calculate the target movement speed based on input
        float targetSpeed = isMoving ? (Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed) : 0f;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        // Update the Animator parameters
        animator.SetBool("isMoving", isMoving);
        animator.SetFloat("MoveSpeed", currentSpeed);

        // Move the character based on the new speed
        Vector3 moveDirection = playerCamera.forward * vertical + playerCamera.right * horizontal;
        moveDirection.y = 0f;
        moveDirection.Normalize();
        if (vertical < 0f) // Move backward slower
            moveDirection *= 0.5f;

        characterController.Move(moveDirection * currentSpeed * Time.deltaTime);

        // Handle Jumping
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            characterController.Move(Vector3.up * jumpForce * Time.deltaTime);
            isGrounded = false; // Prevent consecutive jumps while in the air
        }

        // Use the mouse input to rotate the playerCamera around the character
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        // Rotate the character around the Y-axis based on the horizontal mouse movement.
        transform.Rotate(Vector3.up, mouseX);

        // Rotate the camera around the X-axis based on the vertical mouse movement.
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        // Apply the rotation to the cameraLookAtPoint
        cameraLookAtPoint.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        // Position the camera to be behind the player and look at the cameraLookAtPoint
        playerCamera.position = transform.position - playerCamera.forward * 2f;
        playerCamera.LookAt(cameraLookAtPoint);
    }
}