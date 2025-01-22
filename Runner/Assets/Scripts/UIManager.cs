using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlayerController playerController;

    public TMP_Text playerPointsText;
    public TMP_Text backgroundPoints;

    public Image shieldIcon;
    public Image hp1Image; // Reference to the first heart image
    public Image hp2Image; // Reference to the second heart image

    // Start is called before the first frame update
    void Start()
    {
        shieldIcon.enabled = false;
        UpdateHealthUI(playerController.currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        playerPointsText.text = playerController.points.ToString(); // Converts "Points" from player controller to text
        backgroundPoints.text = playerController.points.ToString();
    }

    // Add this method to check if the shield icon is enabled
    public bool IsShieldIconEnabled()
    {
        return shieldIcon.enabled;
    }
    public void UpdateHealthUI(int currentHealth)
    {
        if (currentHealth == 2)
        {
            hp1Image.enabled = true;
            hp2Image.enabled = true;
        }
        else if (currentHealth == 1)
        {
            hp1Image.enabled = true;
            hp2Image.enabled = false;
        }
        else if (currentHealth == 0)
        {
            hp1Image.enabled = false;
            hp2Image.enabled = false;
        }
    }
}