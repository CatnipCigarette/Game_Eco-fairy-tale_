using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Win;
    public string[] trashTags; // Массив с тегами мусора

    private void Update()
    {
        // Проверяем, выполнены ли условия для завершения игры
        if (CheckGameFinished())
        {
            // Все мусоры убраны в нужные мусорки. Выводим сообщение в консоль.
            Win.SetActive(true);
        }
    }

    private bool CheckGameFinished()
    {
        // Проходим по каждому тегу мусора
        foreach (string trashTag in trashTags)
        {
            // Получаем все объекты мусора с текущим тегом на сцене
            GameObject[] trashItems = GameObject.FindGameObjectsWithTag(trashTag);

            // Проверяем, остался ли хотя бы один объект мусора с текущим тегом на сцене
            if (trashItems.Length > 0)
            {
                return false; // Игра еще не завершена
            }
        }

        return true; // Игра завершена
    }
}
