using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public PlayerController playerController; // Reference to the player controller
    public UIManager uiManager;
    public ScoreManager scoreManager; // Reference to ScoreManager (add this)

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        scoreManager = GameObject.FindObjectOfType<ScoreManager>(); // Ensure the reference is set
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
                // Player doesn't have a shield, trigger damage
                playerController.TakeDamage(); // Call TakeDamage from PlayerController

                // Call the ScoreManager to pause the score when the player hits an obstacle
                scoreManager.PauseScore(); // Pause the score

                // Optionally, destroy the obstacle after the player takes damage
                Destroy(gameObject); // Destroy the obstacle
            }
        }
    }
}
