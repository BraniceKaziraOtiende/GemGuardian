using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameUI : MonoBehaviour
{
    public void ReplayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");  // CHANGE TO YOUR SCENE NAME
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");   // CHANGE TO YOUR MENU NAME
    }
}