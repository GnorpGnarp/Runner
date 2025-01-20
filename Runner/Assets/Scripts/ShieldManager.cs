using System.Collections;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    public GameObject shieldGameObject; // Reference to the shield GameObject
    public float shieldDuration = 10f; // Duration the shield will last
    private bool isShieldActive = false; // To track if the shield effect is active for the player
    private PlayerController playerController; // Reference to the player controller

    void Start()
    {
        // Initialize references
        playerController = FindObjectOfType<PlayerController>(); // Get the player controller instance
    }

    // Method to activate the shield for the player
    public void ActivateShield()
    {
        if (!isShieldActive) // Only activate the shield if it's not already active
        {
            isShieldActive = true;
            // Activate the shield effect for the player (this could involve setting transparency, invincibility, etc.)
            playerController.playerHasShield = true; // Update the player state

            // Start a coroutine to deactivate the shield after the specified duration
            StartCoroutine(ShieldDuration());
        }
    }

    // Coroutine to handle the shield duration
    private IEnumerator ShieldDuration()
    {
        yield return new WaitForSeconds(shieldDuration); // Wait for the shield to expire

        DeactivateShield(); // Deactivate the shield once time is up
    }

    // Method to deactivate the shield
    public void DeactivateShield()
    {
        if (isShieldActive)
        {
            isShieldActive = false;
            // Deactivate the shield visual effect (could involve transparency or invincibility logic)
            playerController.playerHasShield = false; // Update player state
        }
    }

    // Method to check if the shield is active for the player
    public bool IsShieldActive()
    {
        return isShieldActive;
    }

    // Call this method when the player picks up the shield (shield in the world)
    public void OnShieldPickup()
    {
        // Destroy the shield object from the world (since the player can’t pick it up again)
        Destroy(shieldGameObject);

        // Activate the shield effect for the player
        ActivateShield();
    }
}
