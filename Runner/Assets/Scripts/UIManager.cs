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

    public Image background;

    // Start is called before the first frame update
    void Start()
    {
        shieldIcon.enabled = false;
        background.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        playerPointsText.text = playerController.points.ToString(); //Konwertuje wartosc "Points" ktora jest liczb¹ ca³kowita ze skryptu gracza do postaci tekstu
        backgroundPoints.text = playerController.points.ToString();
    }
}
