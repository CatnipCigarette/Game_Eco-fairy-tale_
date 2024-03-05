using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject Win11;
    public GameObject Game;

    void Update()
    {
        // ���������, ����������� �� �����
        if (Time.timeScale == 0f)
        {
            // ���� ����� �����������, ���������� ������ Win11
            Game.SetActive(false);
            Win11.SetActive(true);
        }
        else
        {
            // ���� ����� �� �����������, ������������ ������ Win11 (���� �� �������)
            if (Win11.activeSelf)
            {
                Win11.SetActive(false);
            }
        }
    }
}
