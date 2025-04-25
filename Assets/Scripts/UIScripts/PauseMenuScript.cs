using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    // Referência ao GameObject do menu de pausa
    public GameObject pauseMenuUI;
    // Referências aos botões
    public Button resumeButton;
    public Button quitButton;

    private bool isPaused = false;

    void Start()
    {
        // Inicialmente, esconder o menu de pausa
        pauseMenuUI.SetActive(false);

        // Registrar os callbacks dos botões
        resumeButton.onClick.AddListener(ResumeGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    void Update()
    {
        // Verificar se a tecla "Esc" foi pressionada
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Retomar o tempo do jogo
        isPaused = false;
    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Pausar o tempo do jogo
        isPaused = true;
    }

    void QuitGame()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit();

#if UNITY_EDITOR
        // Parar o jogo no editor do Unity
        EditorApplication.isPlaying = false;
#endif
    }
}

