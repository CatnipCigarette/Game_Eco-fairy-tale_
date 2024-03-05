using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SoundOnHover : MonoBehaviour, IPointerEnterHandler
{
    public AudioClip hoverSound; // Звук, который будет воспроизводиться при наведении
    private Button button; // Компонент кнопки
    private AudioSource audioSource; // Компонент для воспроизведения звука

    void Start()
    {
        // Получаем компоненты
        button = GetComponent<Button>();
        audioSource = gameObject.AddComponent<AudioSource>();

        // Устанавливаем звук для воспроизведения
        audioSource.clip = hoverSound;

        // Регистрируем текущий объект как слушателя события наведения мыши
        button.gameObject.AddComponent<EventTrigger>().triggers.Add(GetEventTriggerEntry());
    }

    private EventTrigger.Entry GetEventTriggerEntry()
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener((eventData) => { PlayHoverSound(); });
        return entry;
    }

    void PlayHoverSound()
    {
        // Воспроизводим звук
        audioSource.Play();
    }

    // Реализация интерфейса IPointerEnterHandler
    public void OnPointerEnter(PointerEventData eventData)
    {
        PlayHoverSound();
    }
}
