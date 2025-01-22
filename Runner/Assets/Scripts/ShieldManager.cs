using System.Collections;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    public GameObject shieldGameObject; // Reference to the shield GameObject
    public UIManager uiManager; // Reference to the UIManager
    private PlayerController playerController; // Reference to the player controller

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>(); // Find the player controller
        if (uiManager == null)
        {
            uiManager = FindObjectOfType<UIManager>(); // Find the UIManager if not assigned
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Shield collected!");

            // Call the method to activate the shield for the player
            ActivateShield();

            // Disable the MeshRenderer and Collider but keep the object active
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            Collider collider = GetComponent<Collider>();

            if (meshRenderer != null)
            {
                meshRenderer.enabled = false; // Disable MeshRenderer
            }

            if (collider != null)
            {
                collider.enabled = false; // Disable Collider
            }

            // Log the GameObject's state after modifications
            Debug.Log("Shield GameObject active after disabling mesh and collider: " + gameObject.activeSelf);
        }
    }

    public void ActivateShield()
    {
        if (uiManager == null)
        {
            Debug.LogError("UIManager is not assigned.");
            return;
        }

        if (!gameObject.activeSelf)
        {
            Debug.LogWarning("Shield GameObject is not active. Cannot activate shield.");
            return;
        }

        // Activate the shield effect for the player
        playerController.playerHasShield = true;

        // Show shield icon on the UI
        uiManager.shieldIcon.enabled = true;
        Debug.Log("Shield icon enabled.");

        // Enable emission effect
        playerController.EnableEmission();

        // Start the shield duration coroutine
        StartCoroutine(ShieldDuration());
    }

    private IEnumerator ShieldDuration()
    {
        yield return new WaitForSeconds(5f);  // Duration of the shield

        // Deactivate the shield after the duration ends
        DeactivateShield();
    }

    public void DeactivateShield()
    {
        // Deactivate the shield effect
        playerController.playerHasShield = false;

        // Hide the shield icon on the UI
        uiManager.shieldIcon.enabled = false;

        // Disable emission effect
        playerController.DisableEmission();

        // After deactivating the shield, you can safely disable the GameObject if needed
        this.gameObject.SetActive(false);
    }
}
