using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Animator animator;
    public int points = 0;
    public GameObject shieldGameObject;
    public bool playerHasShield = false;
    public AudioClip jumpSound;
    public AudioSource jumpAudioSource;
    public AudioSource soundTrackAudioSource;
    public AudioClip backgroundMusic;
    public int level = 0;

    public int maxHealth = 2; // Total number of hearts (can be adjusted)
    public int currentHealth; // Current health of the player

    private Material currentMaterial; // To store the current material
    private SkinnedMeshRenderer skinnedMeshRenderer;


    void Start()
    {
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        currentHealth = maxHealth; // Set the initial health

        // Ensure the material is an instance (not shared)
        if (skinnedMeshRenderer != null)
        {
            currentMaterial = new Material(skinnedMeshRenderer.material);
            skinnedMeshRenderer.material = currentMaterial;
            
        }
    }

    void Update()
    {
        if (level == 0)
        {
            if (Input.GetKey(KeyCode.A))
            {
                if (transform.position.x > -0.5f)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
                }
            }

            if (Input.GetKey(KeyCode.D))
            {
                if (transform.position.x < 7f)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.Play("Jump");

            if (!jumpAudioSource.isPlaying)
            {
                jumpAudioSource.PlayOneShot(jumpSound);
            }
        }
    }

    public void TakeDamage()
    {
        if (currentHealth > 0)
        {
            currentHealth--;
            // Call the UIManager to update health UI
            FindObjectOfType<UIManager>().UpdateHealthUI(currentHealth);

            if (currentHealth <= 0)
            {
                // Player is out of hearts, handle game over logic here
                Debug.Log("Game Over!");
                SceneManager.LoadScene("gameover");
                // Optionally add a game over screen or reset
            }
        }
    }
}
