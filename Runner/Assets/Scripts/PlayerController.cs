using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2f; //Predkosc przesuwania gracza na boki

    public Animator animator; //referencja do animatora

    public int points = 0;

    public GameObject shieldGameObject;

    public bool playerHasShield = false;

    public AudioClip jumpSound;
    public AudioSource jumpAudioSource;

    public AudioSource soundTrackAudioSource;
    public AudioClip backgroundMusic;

    public int level = 0;


    // Start is called before the first frame update
    void Start()
    {
        shieldGameObject.SetActive(false);
        playerHasShield = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (level == 0)
        {
            if (Input.GetKey(KeyCode.A)) //Jezeli wcisniemy przycisk A
            {
                if (transform.position.x > -4f) // Jezeli pozycja gracza w osi X jest wiêksza od -4 to wykonaj to co wewnatrz     || oznacza "lub"
                {
                    //Wykonuje sie to jezeli warunek jest spe³niony
                    transform.Translate(Vector3.left * Time.deltaTime * moveSpeed); //transform.Translate przesuwa obiekt o Vector
                }
                else // Jezeli warunek nie jest spelniony
                {
                    // Tutaj wykonuja sie te rzeczy
                }
            }

            if (Input.GetKey(KeyCode.D))
            {
                if (transform.position.x < 4f)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
                }
            }
        }

        if (level == 1)
        {
            if (Input.GetKey(KeyCode.A)) //Jezeli wcisniemy przycisk A
            {
                if (transform.position.x > -64f) // Jezeli pozycja gracza w osi X jest wiêksza od -4 to wykonaj to co wewnatrz     || oznacza "lub"
                {
                    //Wykonuje sie to jezeli warunek jest spe³niony
                    transform.Translate(Vector3.left * Time.deltaTime * moveSpeed); //transform.Translate przesuwa obiekt o Vector
                }
                else // Jezeli warunek nie jest spelniony
                {
                    // Tutaj wykonuja sie te rzeczy
                }
            }

            if (Input.GetKey(KeyCode.D))
            {
                if (transform.position.x < -56f)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
                }
            }
        }



        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            animator.Play("Jump"); //Animator ma w³¹czyc animacje ze stanu o nazwie "Jump"

            if (jumpAudioSource.isPlaying) // sprawdzenie czy jumpAudioSource odtwarza jakis dzwiek
            {
                // Jezeli tak 
            }
            else
            {
                // jezeli nie 
                jumpAudioSource.PlayOneShot(jumpSound);
            }
        }
    }
}
