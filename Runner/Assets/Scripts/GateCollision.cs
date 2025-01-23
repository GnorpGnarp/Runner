using UnityEngine;
using UnityEngine.SceneManagement;

public class GateCollision : MonoBehaviour
{
    // This function will be called when another collider enters the trigger area
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player has collided with the gate
        if (other.CompareTag("Player"))  // Ensure your player has the "Player" tag
        {
            // Load the Victory scene
            SceneManager.LoadScene("Victory");
        }
    }
}
