using UnityEngine;

public class ColliderFollowPlayer : MonoBehaviour
{
    // Reference to the player object
    public GameObject player;

    // Reference to the player's Rigidbody component, if applicable
    private Rigidbody playerRigidbody;

    // Optionally, you can assign the collider manually if needed
    private Collider playerCollider;

    void Start()
    {
        // If the player is not assigned, find the player in the scene
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        // Get the player's Rigidbody and Collider
        if (player != null)
        {
            playerRigidbody = player.GetComponent<Rigidbody>();
            playerCollider = player.GetComponent<Collider>();
        }
    }

    void Update()
    {
        // If the player and its Rigidbody/Collider are found, update the collider's position
        if (player != null && playerRigidbody != null)
        {
            // Make sure the collider follows the player's position, including Y-axis (vertical movement)
            transform.position = playerRigidbody.position;

            // Optionally, update the collider's rotation if needed
            transform.rotation = playerRigidbody.rotation;
        }
    }
}
