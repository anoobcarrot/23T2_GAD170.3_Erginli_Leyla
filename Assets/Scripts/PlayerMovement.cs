using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    // INSTRUCTIONS
    // This script must be on an object that has a Character Controller component.
    // It will add this component if the object does not already have it.
    //    This is done by line 4: "[RequireComponent(typeof(CharacterController))]"
    //
    // Also, make a camera a child of this object and tilt it the way you want it to tilt.
    // The mouse will let you turn the object, and therefore, the camera.

    // These variables (visible in the inspector) are for you to set up to match the right feel
    private float speed = 12f;
    private float speedH = 2.0f;
    private float speedV = 2.0f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    Animator anim;
    Rigidbody rb;

    [SerializeField] private LavaAndTutorial lavaAndTutorial;

    [SerializeField] private PlayerDeath playerDeath;

    [SerializeField] private bool allowMovement = true;

    // SPRINTING
    [SerializeField] private bool isSprinting = false;
    [SerializeField] private float sprintSpeed = 21f;
    [SerializeField] private float normalSpeed;

    // SPAWN
    [SerializeField] private Transform spawnPoint; // Reference to the spawn point Transform

    // This must be linked to the object that has the "Character Controller" in the inspector. You may need to add this component to the object
    public CharacterController controller;
    private Vector3 velocity;

    // Customisable gravity
    public float gravity = -20f;

    // Tells the script how far to keep the object off the ground
    public float groundDistance = 0.4f;

    // So the script knows if you can jump!
    private bool isGrounded;

    // How high the player can jump
    public float jumpHeight = 2f;

    private void Start()
    {
        // If the variable "controller" is empty...
        if (controller == null)
        {
            // ...then this searches the components on the gameobject and gets a reference to the CharacterController class
            controller = GetComponent<CharacterController>();
        }
        // Store the initial normal walking speed
        normalSpeed = speed;

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            Debug.Log("Collided with ground"); // Debug statement
            TeleportToSpawn();
        }
    }

    private void TeleportToSpawn()
    {
        Debug.Log("Teleporting to spawn point");

        // Disable player movement during teleport
        controller.enabled = false;

        // Teleport the player to the spawn point
        transform.position = spawnPoint.position;

        // Enable player movement after teleport
        controller.enabled = true;
    }

    private void Update()
    {
        if (!allowMovement)
            return; // Don't process movement if it's not allowed

        // These lines let the script rotate the player based on the mouse moving
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        // Get the Left/Right and Forward/Back values of the input being used (WASD, Joystick etc.)
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = Vector3.zero; // Declare the move variable

        // Let the player jump if they are on the ground and they press the jump button
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            anim.SetTrigger("jump");
        }

        // Rotate the player based off those mouse values we collected earlier
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);

        // This is stealing the data about the player being on the ground from the character controller
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // This fakes gravity!
        velocity.y += gravity * Time.deltaTime;

        {
            // Update the 'move' variable here
            move = transform.right * x + transform.forward * z;

            // Finally, it applies that vector it just made to the character
            controller.Move(move * speed * Time.deltaTime + velocity * Time.deltaTime);

            bool isMoving = move.magnitude > 0.1f;

            if (isMoving)
            {
                anim.SetInteger("Walk", 1); // Set the walk animation
            }
            else
            {
                anim.SetInteger("Walk", 0); // Set the idle animation
            }

            // Check for sprint input
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                isSprinting = true;
                speed = sprintSpeed; // Set the speed to the sprint speed
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                isSprinting = false;
                speed = normalSpeed; // Reset the speed to normal
            }

            if (isSprinting)
            {
                speed = sprintSpeed; // Set the speed to the sprint speed
            }
            else
            {
                speed = normalSpeed; // Reset the speed to normal
            }
            
            if (lavaAndTutorial.isPlayerDead == true)

            // Disable movement for all player characters
                DisableMovement();
            }
        }
        // Method to enable or disable movement
        public void SetAllowMovement(bool allow)
        {
            allowMovement = allow;
        }

    public void DisableMovement()
    {
        allowMovement = false;
    }

    public void EnableMovement()
    {
        allowMovement = true;
    }

}


