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
        // Ensure UIManager is assigned
        if (uiManager == null)
        {
            Debug.LogError("UIManager is not assigned.");
            return;
        }

        // Ensure the GameObject is active
        Debug.Log("Shield GameObject active before activation: " + gameObject.activeSelf);

        if (!gameObject.activeSelf)
        {
            Debug.LogWarning("Shield GameObject is not active. Cannot activate shield.");
            return;  // Return early if the object is not active.
        }

        // Activate the shield effect for the player
        playerController.playerHasShield = true;

        // Show shield icon on the UI
        uiManager.shieldIcon.enabled = true;
        Debug.Log("Shield icon enabled.");

        // Check if the shield icon is enabled (using the method we just added)
        if (uiManager.IsShieldIconEnabled())
        {
            Debug.Log("The shield icon is currently enabled!");
        }
        else
        {
            Debug.Log("The shield icon is not enabled.");
        }

        // Make the player transparent
        SetPlayerTransparency(true);

        // Start the shield duration coroutine
        StartCoroutine(ShieldDuration());
    }

    private IEnumerator ShieldDuration()
    {
        yield return new WaitForSeconds(5f); // Duration of the shield (in seconds)

        // Deactivate the shield after the duration ends
        DeactivateShield();
    }

    public void DeactivateShield()
    {
        // Deactivate the shield effect
        playerController.playerHasShield = false;

        // Hide the shield icon on the UI
        uiManager.shieldIcon.enabled = false;

        // Reset the player's transparency (make the player opaque again)
        SetPlayerTransparency(false);

        // After deactivating the shield, you can safely disable the GameObject if needed.
        this.gameObject.SetActive(false); // This can be done here, after the coroutine finishes.
    }

    void SetPlayerTransparency(bool isTransparent)
    {
        Renderer playerRenderer = playerController.GetComponent<Renderer>();

        if (playerRenderer != null)
        {
            Material material = playerRenderer.material;

            if (isTransparent)
            {
                // Set the material to transparent (make the player see-through)
                Color color = material.color;
                color.a = 0.5f; // Set alpha to 50%
                material.color = color;

                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                material.SetInt("_ZWrite", 0);
                material.DisableKeyword("_ALPHATEST_ON");
                material.DisableKeyword("_ALPHABLEND_ON");
                material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = 3000;

                material.SetFloat("_Mode", 3); // Set to Transparent mode (if using Standard Shader)
            }
            else
            {
                // Reset to opaque (make the player fully visible)
                Color color = material.color;
                color.a = 1f; // Set alpha to 100% (fully opaque)
                material.color = color;

                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                material.SetInt("_ZWrite", 1);
                material.EnableKeyword("_ALPHATEST_ON");
                material.EnableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = -1;

                material.SetFloat("_Mode", 0); // Set to Opaque mode (if using Standard Shader)
            }
        }
    }

}
