using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetect : MonoBehaviour
{
    public PlayerController playerController;

    public UIManager uiManager;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) //Metoda która na wejsciu w kolizje zostaje wykonana
    {
        if (collision.gameObject.tag == "Obstacle") //Czy gameobject z ktorym doszlo do kolizji ma tag "Obstacle"
        {
            Debug.Log("doszlo do kolizji z przeszkod¹"); //Debug.Log wyswietla nam informacje w konsoli

            if (playerController.playerHasShield) //Jezeli gracz posiada tarcze (zmienna "playerHasShield = true)
            {
                playerController.playerHasShield = false;   //Zmiana wartosci "PlayerHasShield" na fa³sz
                playerController.shieldGameObject.SetActive(false); //Wy³¹czenie obiektu "kulki"
                uiManager.shieldIcon.enabled = false;

            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Scene Manager wczytuje scene ktora akutualnie jest aktywna
            }
        }

        if (collision.gameObject.tag == "Shield")
        {
            Debug.Log("zebrano tarcze");
            playerController.playerHasShield = true; //Zmiena wartosc zmiennej "playerHasShield" w skrypcie gracza na "prawda"
            playerController.shieldGameObject.SetActive(true); //W³¹cza obiekt wizualizujacy tarcze (Kulka)

            uiManager.shieldIcon.enabled = true;

            Destroy(collision.gameObject);
        }

    }
}
