using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFirstPersonController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;           // Movement speed
    public float jumpForce = 5f;           // Jump force
    public float gravity = -9.81f;         // Gravity strength

    [Header("Mouse Settings")]
    public float mouseSensitivity = 2f;   // Mouse sensitivity for smooth look
    public float mouseSmoothTime = 0.1f;  // Smoothing time

    [Header("Ground Check")]
    public Transform groundCheck;         // Ground check object
    public float groundDistance = 0.4f;   // Radius for ground detection
    public LayerMask groundMask;          // Ground layer mask

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    private Vector2 currentMouseDelta;    // Current smoothed mouse delta
    private Vector2 currentMouseDeltaVelocity; // For smooth damping
    private float xRotation = 0f;

    void Awake()
    {
        if (GameObject.Find("Ground") != null)
        {
            groundCheck = GameObject.Find("Ground").transform;
        }
        else
        {
            Debug.LogError("I cannot find any Game Object named Ground in the current scene");
        }

    }

    void Start()
    {
        // Lock the cursor to the game window
        Cursor.lockState = CursorLockMode.Locked;

        // Get the CharacterController component
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (groundCheck == null) return;
        HandleMovement();
        HandleMouseLook();
    }

    private void HandleMovement()
    {
        // Ground Check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Reset downward velocity to keep grounded
        }

        // Get input for movement
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down

        // Calculate movement direction in local space
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Move the player
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Apply vertical velocity
        controller.Move(velocity * Time.deltaTime);
    }

    private void HandleMouseLook()
    {
        // Get raw mouse input
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        // Smooth the mouse input using damping
        Vector2 targetMouseDelta = new Vector2(mouseX, mouseY);
        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

        // Apply smoothed mouse input to rotation
        xRotation -= currentMouseDelta.y * mouseSensitivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp vertical rotation

        // Rotate camera up and down
        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate player left and right
        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }
}


