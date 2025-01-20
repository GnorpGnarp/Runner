using UnityEngine;

public class ShieldPickupController : MonoBehaviour
{
    public ShieldManager shieldManager;
    public UIManager uiManager;

    // Handle shield pickup collision
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shieldManager.ActivateShield(); // Activate the shield
            uiManager.shieldIcon.enabled = true; // Show the shield icon
            Destroy(gameObject); // Destroy the shield object after pickup
        }
    }
}
