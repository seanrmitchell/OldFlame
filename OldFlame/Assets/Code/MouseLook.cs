using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public Transform playerBody;

    [SerializeField]
    private float mouseSensitivity = 100f;

    private float mouseXAxis, mouseYAxis;
    private float xRot = 0f;
    private float yRot = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Gets raw mouse input per pixel
        mouseXAxis = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseYAxis = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Updated subtration of vertical motion of mouse.
        // Moving up decreases (up), and Moving down increases (down)
        xRot -= mouseYAxis;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        // Updates Y-Axis Rotation based on horizontal movement of mouse
        // Moving left decreases (left), and moving right increases (right)
        yRot += mouseXAxis;

        // Applies to player and camera
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseXAxis);
    }
}
