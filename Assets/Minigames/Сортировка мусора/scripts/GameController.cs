using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Win;
    public string[] trashTags; // ������ � ������ ������

    private void Update()
    {
        // ���������, ��������� �� ������� ��� ���������� ����
        if (CheckGameFinished())
        {
            // ��� ������ ������ � ������ �������. ������� ��������� � �������.
            Win.SetActive(true);
        }
    }

    private bool CheckGameFinished()
    {
        // �������� �� ������� ���� ������
        foreach (string trashTag in trashTags)
        {
            // �������� ��� ������� ������ � ������� ����� �� �����
            GameObject[] trashItems = GameObject.FindGameObjectsWithTag(trashTag);

            // ���������, ������� �� ���� �� ���� ������ ������ � ������� ����� �� �����
            if (trashItems.Length > 0)
            {
                return false; // ���� ��� �� ���������
            }
        }

        return true; // ���� ���������
    }
}
