using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaController : MonoBehaviour
{
    public UIManager manager;

    public Transform playerTransform;

    public bool isExitGameMeta;

    public Transform secondStageStartPoint;
    public GroundController secondStageGroundController;

    public Transform cameraTransform;
    public Transform secondStageCameraPosition;

    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < 0)
        {
            if (isExitGameMeta)
            {
                manager.background.gameObject.SetActive(true);
            }
            else
            {
                
                playerTransform.position = secondStageStartPoint.position;
                cameraTransform.position = secondStageCameraPosition.position;
                playerController.level++;
                secondStageGroundController.startMove = true;

                Destroy(gameObject);


            }
            // Wyswietlamy background koncowy
        }
    }
}
