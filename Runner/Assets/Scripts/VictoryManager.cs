using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
    // Method to load the MainMenu scene
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private static void QuitApplication()
    {
        Debug.Log("Quitting...");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit(); // Quits the game when built
#endif
    }
}
