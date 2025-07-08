using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Transform player;
    public Transform[] teleportTargets; // posições dos níveis
    public GameObject gameOverScreen;
    public GameObject winScreen;
    public GameObject howToPlayScreen;
    public GameObject howToFireScreen;

    public static event Action OnReset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerHealth.OnPlayerDied += GameOverScreen;
        gameOverScreen.SetActive(false);
        DomClaudioHealth.OnClaudioDied += WinScreen;
        winScreen.SetActive(false);
    }

    void GameOverScreen()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0; //pausa o jogo completamente
    }

    void WinScreen()
    {
        winScreen.SetActive(true);
        PauseController.SetPause(true);
    }

    public void ResetGame()
    {
        gameOverScreen.SetActive(false);
        SetLevel(CurrentLevel()); //trocar para outros niveis
        OnReset.Invoke();
        Time.timeScale = 1;
    }

    void SetLevel(int level)
    {
        player.position = teleportTargets[level].position; //mudar para teleport point do level
    }

    int CurrentLevel()
    {
        float X = player.position.x;
        float Y = player.position.y;
        if (X > -14f && X < 17f && Y < 25f && Y > -6f) return 0;
        if (X > -74f && X < -6.71f && Y < 73.4f && Y > 41f) return 1;
        if (X < -63.69f && X > -103.8f && Y < 21 && Y > -3) return 2;
        return 3;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void MenuGame()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void ExitHowToPlayScreen()
    {
        howToPlayScreen.SetActive(false);
        PauseController.SetPause(false);
    }

    public void ExitHowToFireScreen()
    {
        howToFireScreen.SetActive(false);
        PauseController.SetPause(false);
    }
}
