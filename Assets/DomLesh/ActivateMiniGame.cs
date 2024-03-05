using UnityEngine;
using UnityEngine.UI;

public class ActivateMiniGame : MonoBehaviour
{
    public GameObject MiniGameContainer;
    public GameObject Rule;

    private void Start()
    {
        // Находим кнопку по тегу или другим способом
        Button button = GetComponent<Button>();

        // Добавляем обработчик события нажатия на кнопку
        button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        // Делаем MiniGameContainer активным
        MiniGameContainer.SetActive(true);
        Rule.SetActive(false);
    }
}
