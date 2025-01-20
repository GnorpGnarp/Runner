using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetect : MonoBehaviour
{
    public PlayerController playerController;
    public bool playerHasShield = false; // Shield flag
    public UIManager uiManager;
    public GameObject shieldGameObject;

    public ShieldManager shieldManager; // Reference to ShieldManager

    // Start is called before the first frame update
    void Start()
    {
        // Optionally, find the ShieldManager if not assigned in the Inspector
        if (shieldManager == null)
        {
            shieldManager = FindObjectOfType<ShieldManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered with: " + other.gameObject.name);

        if (other.gameObject.CompareTag("Obstacle"))
        {
            if (playerController.playerHasShield)
            {
                shieldManager.DeactivateShield(); // Deactivate shield when hitting an obstacle
                uiManager.shieldIcon.enabled = false;
            }
            else
            {
                // Trigger game over UI
                //uiManager.ShowGameOverUI();
                Time.timeScale = 0; // Stops the game (optional)
            }
        }

    }
}
