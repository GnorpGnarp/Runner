using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public PlayerController playerController; // Reference to the player controller
    public UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Handle obstacle collision
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerController.playerHasShield)
            {
                // Player has shield, shield absorbs the obstacle
                playerController.playerHasShield = false;
                uiManager.shieldIcon.enabled = false; // Hide shield icon
                Destroy(gameObject); // Destroy the obstacle
            }
            else
            {
                // Player doesn't have a shield, game over or damage logic
                Time.timeScale = 0; // Stop the game (optional, you might trigger a game over UI)
            }
        }
    }
}
