using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System.Runtime.CompilerServices;
using System;

public class PlayerMove : MonoBehaviour
{
    public Controls playerControls;
    public LayerMask ground;
    public Transform groundCheck;

    [SerializeField] //visible in editor
    private float speed, jumpHeight;

    private CharacterController player;

    private Vector3 movement, direction, velocity;

    private float gravity = -10f;

    private void Awake()
    {
        playerControls = new Controls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //an.SetFloat("speed", Mathf.Abs(movement.magnitude));

        // Checks if the jump key was pressed, and the player is on the ground
        // Performs a jump by adding velocity to the player using jump physics equation
        if (playerControls.Movement.Jump.WasPressedThisFrame() && player.isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravity);
            Debug.Log("jumped + " + velocity.y);
        }

        // Calculates Vector Strafe Inputs
        movement = playerControls.Movement.Strafe.ReadValue<Vector2>();
        direction = movement.x * transform.right + movement.y * transform.forward;

        player.Move(speed * Time.deltaTime * direction);
        //player.Move(Vector3.up * -1f);

        if (player.isGrounded && velocity.y < 0)
        {
            // Sets base y velocity to -2f if on ground
            velocity.y = -2f;
        }

        // Applies negative gravity to velocity, and applies y velocity vector to character controller
        velocity.y += gravity * Time.deltaTime;
        player.Move(velocity * Time.deltaTime);
    }
}