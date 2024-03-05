using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    public Button restartButton; // ��������� ������ ����������� � ����������
    public FishingRod fishingRod; // ��������� ������ FishingRod � ����������

    private void Start()
    {
        // �������� ���������� ������� �� ������ �����������
        restartButton.onClick.AddListener(RestartGame);
    }

    private void RestartGame()
    {
        // �������� ����� �������������� �������� �� ������� FishingRod
        fishingRod.RestoreObjects();
    }
}
