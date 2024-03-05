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

    private bool isNearDoor = false; // ����, �����������, ��������� �� �������� ����� � �������

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
        Color startingColor = new Color(0f, 0f, 0f, 0f); // ����������� ���� � �����-������� 0 (��������� ����������)
        Color targetColor = Color.black; // ������� ���� - ������
        float duration = 2f; // ������������ ���������� � ��������
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            imagin.color = Color.Lerp(startingColor, targetColor, t);
            yield return null;
        }

        // ���������� ��������� ����
        imagin.color = targetColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Door")) // ��������, ��� �������� ������� � ������ (����� ������������� ��������� ��� ������ �������)
        {
            isNearDoor = true;
            text.SetActive(true); // �������� ������ E
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Door")) // ��������, ��� �������� ������� ������ (����� ������������� ��������� ��� ������ �������)
        {
            isNearDoor = false;
            text.SetActive(false); // ������ ������ E
        }
    }

    public void LoadScene()
    {
        GameObject musicList = GameObject.Find("MusicList"); // ����� ������ MusicList
        SceneManager.LoadScene(LlOdSc);
    }
}
