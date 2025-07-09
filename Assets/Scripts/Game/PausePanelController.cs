using UnityEngine;

public class PausePanelController : MonoBehaviour
{
    public GameObject pausePanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausePanel.activeSelf && PauseController.isGamePaused)
            {
                return;
            }
            pausePanel.SetActive(!pausePanel.activeSelf);
            if (pausePanel.activeSelf)
            {
                Time.timeScale = 0; //pausa o jogo completamente
            }
            else
                Time.timeScale = 1;
            //PauseController.SetPause(pausePanel.activeSelf);
        }
    }
}
