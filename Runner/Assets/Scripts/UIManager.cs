using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlayerController playerController;
    public TMP_Text playerPointsText; // This will display the score, which can also represent avoided obstacles

    public Image shieldIcon;
    public Image hp1Image;
    public Image hp2Image;

    void Start()
    {
        shieldIcon.enabled = false;
        UpdateHealthUI(playerController.currentHealth);
    }

    void Update()
    {
        // Display the player's points (which also represents the number of avoided obstacles)
        playerPointsText.text = "Score: " + playerController.points.ToString();
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
