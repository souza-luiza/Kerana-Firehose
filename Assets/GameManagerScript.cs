using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;

    void Start()
    {
        // Garante que a UI de game over comece desativada
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
        }

        // Esconde e trava o cursor para o início do jogo
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // A função Update() não é necessária para controlar o cursor neste caso.
    // A lógica de mostrar/esconder o cursor será ativada apenas quando o jogo terminar.

    public void gameOver()
    {
        if (gameOverUI != null)
        {
            // Ativa a tela de Game Over
            gameOverUI.SetActive(true);

            // Mostra e desbloqueia o cursor para que o jogador possa clicar nos botões
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void restart()
    {
        // Recarrega a cena atual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restart");
    }

    public void MainMenu()
    {
        // Carrega a cena do Menu Principal (certifique-se de que "MainMenu" existe nas suas Build Settings)
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Main Menu");
    }

    public void quit()
    {
        // Fecha o jogo
        Application.Quit();
        Debug.Log("Quit Game");
    }
}