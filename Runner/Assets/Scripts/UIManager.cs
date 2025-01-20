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
    

    // Start is called before the first frame update
    void Start()
    {
        shieldIcon.enabled = false;
       
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
}

