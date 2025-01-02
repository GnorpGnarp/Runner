using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -2.5f) //Sprawdzamy czy pozycja kostki jest mniejsza niz -2.5 na osi Z
        {
            playerController.points = playerController.points + 1; //Dodajemy do zmiennej Points 1
            Destroy(gameObject); //Niszczymy ten obiekt
        }
    }
}
