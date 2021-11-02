using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isGamePaused = false;
    public GameObject pauseMenu;
    public GameObject playerReference;

    void Start()
    {
        Time.timeScale = 1f; 
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isGamePaused)
            {
                resume();
            }
            else
            {
                pauseGame();
            }
        }
        if (!playerReference.activeSelf)
        {
            pauseGame();
        }
    }

    public void resume()
    {
        if (playerReference.activeSelf)
        {
            isGamePaused = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void pauseGame()
    {
        isGamePaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
