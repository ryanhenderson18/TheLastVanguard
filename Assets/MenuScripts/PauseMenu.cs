using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private GameObject playerReference;
    private bool isGamePaused = false;

    void Start()
    {
        playerReference = GameObject.Find("Player");
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
        if (!playerReference.activeSelf && GameObject.Find("EnergyExplosion(Clone)") == null)
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
