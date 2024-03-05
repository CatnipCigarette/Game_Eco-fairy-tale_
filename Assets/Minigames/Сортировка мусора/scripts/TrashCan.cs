using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public string acceptedTrashTag; // ���, ����������� ��������

    public bool AcceptsTrashTag(string trashTag)
    {
        return trashTag == acceptedTrashTag;
    }

    public bool RejectsTrashTag(string trashTag)
    {
        // ����� ��� ����� ����������� ���� ������ �������� �� ������������ �������.
        // ����������� true, ���� ������� �� ��������� ��������� ��� ������.
        // ����������� false, ���� ������� ��������� ��������� ��� ������.

        // ������ ����������, ������������ ���� ������ � �������:
        if (trashTag == "Paper" && gameObject.tag != "Paper")
        {
            return true; // ������� �� ��������� ������.
        }

        if (trashTag == "Glass" && gameObject.tag != "Glass")
        {
            return true; // ������� �� ��������� ������.
        }

        if (trashTag == "Metal" && gameObject.tag != "Metal")
        {
            return true; // ������� �� ��������� ������.
        }

        if (trashTag == "Organ" && gameObject.tag != "Organ")
        {
            return true; // ������� �� ��������� ������.
        }

        if (trashTag == "Electro" && gameObject.tag != "Electro")
        {
            return true; // ������� �� ��������� ������.
        }

        if (trashTag == "Plastic" && gameObject.tag != "Plastic")
        {
            return true; // ������� �� ��������� ������.
        }

        // �������� �������������� ������� ��� �������� ������ ����� ������ � �������.

        return false; // ������� ��������� ��������� ��� ������.
    }

}
