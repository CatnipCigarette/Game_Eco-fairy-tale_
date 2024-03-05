using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Fungus;

public class Pause : MonoBehaviour
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
                Resume1();
            }
            else
            {
                Pause1();
            }
        }
    }

    public void Resume1()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;

        panel.SetActive(true);
        PauseButton.gameObject.SetActive(true);
    }

    public void Pause1()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 1f;
        PauseGame = true;

        panel.SetActive(false);
        PauseButton.gameObject.SetActive(false);
    }

    public void LoadMenu1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
