using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Keluar");
    }
}