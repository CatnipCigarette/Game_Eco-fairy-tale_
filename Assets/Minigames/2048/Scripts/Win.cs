using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject Win11;
    public GameObject Game;

    void Update()
    {
        // Проверяем, остановлено ли время
        if (Time.timeScale == 0f)
        {
            // Если время остановлено, активируем объект Win11
            Game.SetActive(false);
            Win11.SetActive(true);
        }
        else
        {
            // Если время не остановлено, деактивируем объект Win11 (если он активен)
            if (Win11.activeSelf)
            {
                Win11.SetActive(false);
            }
        }
    }
}
