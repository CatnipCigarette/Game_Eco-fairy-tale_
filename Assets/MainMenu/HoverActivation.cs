using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverActivation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject targetObject; // ������� ������, ������� �� ������ ������������/��������������
    public AudioClip hoverSound;     // ���� ��� ���������
    private AudioSource audioSource;

    private void Start()
    {
        // �� ��������� ������ ������ ����������
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }

        // ��������� ��������� AudioSource � ����������� ���
        audioSource = targetObject.AddComponent<AudioSource>();
        audioSource.clip = hoverSound;
        audioSource.playOnAwake = false;
    }

    // ���������� ��� ��������� �� ������
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (targetObject != null)
        {
            targetObject.SetActive(true);

            // ������������� ���� ��� ���������
            if (audioSource != null && hoverSound != null)
            {
                audioSource.Play();
            }
        }
    }

    // ���������� ��� ������ �� ���� �������
    public void OnPointerExit(PointerEventData eventData)
    {
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
    }
}
