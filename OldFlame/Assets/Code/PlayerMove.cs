using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System.Runtime.CompilerServices;

public class PlayerMove : MonoBehaviour
{
    public Controls playerControls;
    public LayerMask ground;
    public Transform groundCheck;

    [SerializeField] //visible in editor
    private float speed;

    private CharacterController player;

    private Vector3 movement, direction, velocity;

    private bool isGrounded = true;

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
    }

    private void FixedUpdate()
    {
        // Calculates Vector Strafe Inputs
        movement = playerControls.Movement.Strafe.ReadValue<Vector2>();
        direction = movement.x * transform.right + movement.y * transform.forward;

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.4f, ground);

        if (isGrounded)
        {
            // Applies smoothed out vector Vector to Player to sim movement
            player.Move(speed * Time.deltaTime * direction);
            player.Move(Vector3.up * -1f);

            //velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            player.Move(0.5f * velocity * Time.deltaTime);
        }
    }
}