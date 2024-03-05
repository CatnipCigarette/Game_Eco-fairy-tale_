using UnityEngine;

public class TrashItem : MonoBehaviour
{
    private Vector3 startPosition;
    private bool isBeingDragged = false;
    private bool gameFinished = false;

    private void OnMouseDown()
    {
        isBeingDragged = true;
        startPosition = transform.position; // Сохраняем изначальную позицию объекта мусора
    }

    private void OnMouseUp()
    {
        isBeingDragged = false;

        // Проверяем, выполнены ли условия для завершения игры
        //if (CheckGameFinished())
        //{
        //    // Все мусоры убраны в нужные мусорки. Выводим сообщение в консоль.
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
                // Правильная мусорка. Оставляем объект мусора в мусорке.
                // Можно добавить звуковой эффект или анимацию успеха.

                Debug.Log("Правильная мусорка");
                Destroy(gameObject);
            }
            else if (trashCan.RejectsTrashTag(gameObject.tag))
            {
                // Неправильная мусорка. Возвращаем объект мусора на изначальное место.
                isBeingDragged = false;
                transform.position = startPosition;
                Debug.Log("Неправильная мусорка");
                // Можно добавить звуковой эффект или анимацию ошибки.
            }
        }
    }

  //  private bool CheckGameFinished()
   // {
        // Проверяем, выполнены ли условия для завершения игры
        // Например, можно проверить, сколько мусорок пустых, и если все мусорки пустые, вернуть true.

        // Пример проверки: проверяем, есть ли еще активные объекты мусора на сцене
       // GameObject[] trashItems = GameObject.FindGameObjectsWithTag("Trash");
       // if (trashItems.Length == 0)
       // {
      //      gameFinished = true;
      //  }

      //  return gameFinished;
   // }
}
