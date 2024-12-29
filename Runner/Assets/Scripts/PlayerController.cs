using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed
    public float rotationSpeed = 700f; // Rotation speed
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();

        // Make sure the Rigidbody is not kinematic
        if (rb == null)
        {
            Debug.LogError("Rigidbody component is missing!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from horizontal (A/D or Left/Right arrow) and vertical (W/S or Up/Down arrow) keys
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Create a movement vector
        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ).normalized;

        // Move the player using Rigidbody
        if (moveDirection.magnitude >= 0.1f)
        {
            // Apply movement
            Vector3 movement = moveDirection * moveSpeed * Time.deltaTime;
            rb.MovePosition(transform.position + movement);

            // Rotate the player to face the direction of movement
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
