using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Fungus;

public class PauseMenu : MonoBehaviour
{
    public static bool PauseGame;
    public GameObject pauseMenu;
    public GameObject panel;
    public Button PauseButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseGame)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;

        panel.SetActive(true);
        PauseButton.gameObject.SetActive(true);
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;

        panel.SetActive(false);
        PauseButton.gameObject.SetActive(false);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}