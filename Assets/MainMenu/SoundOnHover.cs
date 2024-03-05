using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SoundOnHover : MonoBehaviour, IPointerEnterHandler
{
    public AudioClip hoverSound; // ����, ������� ����� ���������������� ��� ���������
    private Button button; // ��������� ������
    private AudioSource audioSource; // ��������� ��� ��������������� �����

    void Start()
    {
        // �������� ����������
        button = GetComponent<Button>();
        audioSource = gameObject.AddComponent<AudioSource>();

        // ������������� ���� ��� ���������������
        audioSource.clip = hoverSound;

        // ������������ ������� ������ ��� ��������� ������� ��������� ����
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
        // ������������� ����
        audioSource.Play();
    }

    // ���������� ���������� IPointerEnterHandler
    public void OnPointerEnter(PointerEventData eventData)
    {
        PlayHoverSound();
    }
}
