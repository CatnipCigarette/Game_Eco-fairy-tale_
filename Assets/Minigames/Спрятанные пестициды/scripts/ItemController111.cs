using UnityEngine;

public class ItemController111 : MonoBehaviour
{
    private void OnMouseDown()
    {
        // ���� ����� ����� ���������� ��� ����� �� ������ ��������
        // �� ������ �������� ����� ������ ��� ��������� �����, ��������, ��������� ������� ��������� ���������
        // ��� ������ ������� ����� �����

        // ������:
        gameObject.SetActive(false); // �������� ��������� ������� ��� �����
        GameManager.Instance.ItemFound(); // �������� ����� � GameManager ��� ���������� �������� ��������� ���������
    }
}
