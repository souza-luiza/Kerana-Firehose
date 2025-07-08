using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public GameObject startButton;
    public GameObject creditsButton;
    public GameObject exitButton;
    public GameObject creditsText;
    public GameObject returnButton;

    public void OnStartClick()
    {
        SceneManager.LoadScene("Fase1_Melhorada");
    }

    public void OnCreditsEnterClick()
    {
        startButton.SetActive(false);
        creditsButton.SetActive(false);
        exitButton.SetActive(false);
        creditsText.SetActive(true);
        returnButton.SetActive(true);
    }

    public void OnCreditsExitClick()
    {
        creditsText.SetActive(false);
        returnButton.SetActive(false);
        startButton.SetActive(true);
        creditsButton.SetActive(true);
        exitButton.SetActive(true);
    }

    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
