using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    void Awake()
    {
        // Reset the score when the main menu is loaded
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();

        if (scoreManager != null)
        {
            scoreManager.ResetScore(); // Reset the score
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
public void QuitGame()
    {
        Debug.Log("Quitting ggame...");
        Application.Quit();
    }
}