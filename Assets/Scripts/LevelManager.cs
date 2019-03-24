using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None; // tekur af læsingu á músinni
        Cursor.visible = true; // lætur músina ver sýnileg
    }
    // fall sem hleður inn Game sceneinu
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    // fall sem hleður inn MainMenu sceneinu
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    // fall sem hleður inn HowToPlay sceneinu
    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }
    // fall sem stoppar leikinn
    public void QuitGame()
    {
        Application.Quit();
    }
}
