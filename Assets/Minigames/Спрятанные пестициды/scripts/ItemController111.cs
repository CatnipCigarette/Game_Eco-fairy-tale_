using UnityEngine;

public class ItemController111 : MonoBehaviour
{
    private void OnMouseDown()
    {
        // Этот метод будет вызываться при клике на объект предмета
        // Вы можете добавить здесь логику для обработки клика, например, увеличить счетчик найденных предметов
        // Или скрыть предмет после клика

        // Пример:
        gameObject.SetActive(false); // Скрываем найденный предмет при клике
        GameManager.Instance.ItemFound(); // Вызываем метод в GameManager для увеличения счетчика найденных предметов
    }
}
