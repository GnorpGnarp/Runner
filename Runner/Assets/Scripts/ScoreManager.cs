using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public float score = 0f;           // Player's score
    public float scorePerSecond = 1f; // How much score is added per second
    public float hitPauseDuration = 2f; // Delay time after collision before resuming the score
    private bool isPaused = false;    // Whether the score is paused
    private float timeSinceHit = 0f;  // Time elapsed since the player hit an object

    private void Update()
    {
        // If the score is not paused, add score over time
        if (!isPaused)
        {
            score += scorePerSecond * Time.deltaTime;
        }
        else
        {
            // If the score is paused, count the time since the hit
            timeSinceHit += Time.deltaTime;

            // If the delay is over, resume the score counting
            if (timeSinceHit >= hitPauseDuration)
            {
                ResumeScore(); // Resume the score counting
            }
        }
    }

    // Call this method when the player hits an object (to pause the score)
    public void PauseScore()
    {
        isPaused = true;
        timeSinceHit = 0f; // Reset the time counter
    }

    // Call this method to resume the score counting
    public void ResumeScore()
    {
        isPaused = false;
        timeSinceHit = 0f; // Reset the time counter when resuming
    }
    private void Awake()
    {
        // If an instance of ScoreManager already exists, destroy this one
        if (FindObjectOfType<ScoreManager>() != this)
        {
            Destroy(gameObject); // Destroy duplicate
        }
        else
        {
            DontDestroyOnLoad(gameObject); // Keep this instance alive across scene loads
        }
    }
    public void ResetScore()
    {
        score = 0f; // Reset the score to 0
    }

}
