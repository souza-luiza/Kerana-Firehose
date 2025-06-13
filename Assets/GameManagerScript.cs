using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false; // Hide the cursor
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeInHierarchy)
        {
            Cursor.visible = true; // Hide the cursor
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false; // Hide the cursor
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restart");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
       Debug.Log("Main Menu");
    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
