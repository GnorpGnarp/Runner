using UnityEngine;

public class AvoidedObstacleCounter : MonoBehaviour
{
    public PlayerController playerController; // Reference to player controller
    public int avoidedObstacles = 0; // Track the number of obstacles avoided

    void Start()
    {
        if (!playerController) playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Called when an obstacle passes through the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            avoidedObstacles++; // Increase the counter for avoided obstacles
            Destroy(other.gameObject); // Destroy or deactivate the obstacle
            Debug.Log("Obstacles avoided: " + avoidedObstacles);
        }
    }
}
