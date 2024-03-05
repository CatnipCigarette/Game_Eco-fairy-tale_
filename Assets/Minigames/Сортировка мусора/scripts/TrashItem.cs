using UnityEngine;

public class TrashItem : MonoBehaviour
{
    private Vector3 startPosition;
    private bool isBeingDragged = false;
    private bool gameFinished = false;

    private void OnMouseDown()
    {
        isBeingDragged = true;
        startPosition = transform.position; // ��������� ����������� ������� ������� ������
    }

    private void OnMouseUp()
    {
        isBeingDragged = false;

        // ���������, ��������� �� ������� ��� ���������� ����
        //if (CheckGameFinished())
        //{
        //    // ��� ������ ������ � ������ �������. ������� ��������� � �������.
        //    Debug.Log("123345");
        //}
    }

    private void OnMouseDrag()
    {
        if (isBeingDragged)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        TrashCan trashCan = other.GetComponent<TrashCan>();
        if (trashCan != null)
        {
            if (trashCan.AcceptsTrashTag(gameObject.tag))
            {
                // ���������� �������. ��������� ������ ������ � �������.
                // ����� �������� �������� ������ ��� �������� ������.

                Debug.Log("���������� �������");
                Destroy(gameObject);
            }
            else if (trashCan.RejectsTrashTag(gameObject.tag))
            {
                // ������������ �������. ���������� ������ ������ �� ����������� �����.
                isBeingDragged = false;
                transform.position = startPosition;
                Debug.Log("������������ �������");
                // ����� �������� �������� ������ ��� �������� ������.
            }
        }
    }

  //  private bool CheckGameFinished()
   // {
        // ���������, ��������� �� ������� ��� ���������� ����
        // ��������, ����� ���������, ������� ������� ������, � ���� ��� ������� ������, ������� true.

        // ������ ��������: ���������, ���� �� ��� �������� ������� ������ �� �����
       // GameObject[] trashItems = GameObject.FindGameObjectsWithTag("Trash");
       // if (trashItems.Length == 0)
       // {
      //      gameFinished = true;
      //  }

      //  return gameFinished;
   // }
}
