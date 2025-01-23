using UnityEngine;
using TMPro;

public class VictoryUIManager : MonoBehaviour
{
    public TMP_Text victoryScoreText; // Reference to TMP_Text in Victory Scene
    private ScoreManager scoreManager;

    void Start()
    {
        // Find the ScoreManager instance in the scene (since it's persistent across scenes)
        scoreManager = FindObjectOfType<ScoreManager>();

        // Display the score from the ScoreManager
        if (scoreManager != null)
        {
            victoryScoreText.text = "Score: " + Mathf.Floor(scoreManager.score).ToString();
        }
        else
        {
            victoryScoreText.text = "Score: 0";
        }
    }
}
