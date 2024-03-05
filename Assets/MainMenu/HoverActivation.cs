using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverActivation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject targetObject; // Укажите объект, который вы хотите активировать/деактивировать
    public AudioClip hoverSound;     // Звук при наведении
    private AudioSource audioSource;

    private void Start()
    {
        // По умолчанию делаем объект неактивным
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }

        // Добавляем компонент AudioSource и настраиваем его
        audioSource = targetObject.AddComponent<AudioSource>();
        audioSource.clip = hoverSound;
        audioSource.playOnAwake = false;
    }

    // Вызывается при наведении на объект
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (targetObject != null)
        {
            targetObject.SetActive(true);

            // Воспроизводим звук при наведении
            if (audioSource != null && hoverSound != null)
            {
                audioSource.Play();
            }
        }
    }

    // Вызывается при выходе из зоны объекта
    public void OnPointerExit(PointerEventData eventData)
    {
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
    }
}
