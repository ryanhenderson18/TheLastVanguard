using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playSurvival()
    {
        SceneManager.LoadScene(7);
    }
    public void playLevelOne()
    {
        SceneManager.LoadScene(1);
    }
    public void playLevelTwo()
    {
        SceneManager.LoadScene(2);
    }
    public void playLevelThree()
    {
        SceneManager.LoadScene(3);
    }
    public void playLevelFour()
    {
        SceneManager.LoadScene(4);
    }
    public void playLevelFive()
    {
        SceneManager.LoadScene(5);
    }
    public void playBossFight()
    {
        SceneManager.LoadScene(6);
    }
    public void quitGame()
    {
        Debug.Log("Quitting you king");
        Application.Quit();
    }
}
