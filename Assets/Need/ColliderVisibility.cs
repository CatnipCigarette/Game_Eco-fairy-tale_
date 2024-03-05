using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColliderVisibility : MonoBehaviour
{
    public GameObject text; // buttonPrompt; 
    public AudioSource soundSource;
    public Image imagin;
    public string LlOdSc;

    private bool isNearDoor = false; // Флаг, указывающий, находится ли персонаж рядом с деревом

    private void Update()
    {
        if (isNearDoor && Input.GetKeyDown(KeyCode.E))
        {
            text.SetActive(false);
            StartCoroutine(FadeImage());
            soundSource.Play();
            Invoke("LoadScene", 3f);
        }
    }

    private IEnumerator FadeImage()
    {
        Color startingColor = new Color(0f, 0f, 0f, 0f); // Изначальный цвет с альфа-каналом 0 (полностью прозрачный)
        Color targetColor = Color.black; // Целевой цвет - черный
        float duration = 2f; // Длительность затемнения в секундах
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            imagin.color = Color.Lerp(startingColor, targetColor, t);
            yield return null;
        }

        // Установить финальный цвет
        imagin.color = targetColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Door")) // Проверка, что персонаж подошел к дереву (может потребоваться адаптация для вашего проекта)
        {
            isNearDoor = true;
            text.SetActive(true); // Показать кнопку E
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Door")) // Проверка, что персонаж покинул дерево (может потребоваться адаптация для вашего проекта)
        {
            isNearDoor = false;
            text.SetActive(false); // Скрыть кнопку E
        }
    }

    public void LoadScene()
    {
        GameObject musicList = GameObject.Find("MusicList"); // Найти объект MusicList
        SceneManager.LoadScene(LlOdSc);
    }
}
