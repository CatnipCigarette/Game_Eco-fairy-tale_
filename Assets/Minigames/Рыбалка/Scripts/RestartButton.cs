using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    public Button restartButton; // Привяжите кнопку перезапуска в инспекторе
    public FishingRod fishingRod; // Привяжите скрипт FishingRod в инспекторе

    private void Start()
    {
        // Добавьте обработчик события на кнопку перезапуска
        restartButton.onClick.AddListener(RestartGame);
    }

    private void RestartGame()
    {
        // Вызовите метод восстановления объектов из скрипта FishingRod
        fishingRod.RestoreObjects();
    }
}
