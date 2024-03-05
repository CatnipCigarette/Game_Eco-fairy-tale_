using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoaderButton : MonoBehaviour
{
    public string sceneName;
    public GameObject winButton;

    void Start()
    {
        Button button = winButton.GetComponent<Button>();

        button.onClick.AddListener(winButtonOnClick);
    }

    public void winButtonOnClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
}
