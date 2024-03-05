using UnityEngine;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    public BakMov bakMovInstance; // ������ �� ��������� ������ BakMov
    public ItemController itemControllerInstance;

    public GameObject TrashBuk;
    public GameObject restartButton;
    public GameObject restart;
    public Text scoreText;
    public Text healthText;

    void Start()
    {
        Button button = restartButton.GetComponent<Button>();

        button.onClick.AddListener(RestartOnClick);
    }

    void RestartOnClick()
    {
        bakMovInstance.score = 0;
        bakMovInstance.health = 3;

        scoreText.text = "����: " + bakMovInstance.score.ToString();
        healthText.text = "�����: " + bakMovInstance.health.ToString();

        itemControllerInstance.ClearSpawnedItems();

        Vector3 newPosition = TrashBuk.transform.position;
        newPosition.x = -139.2809f;
        TrashBuk.transform.position = newPosition;

        restart.SetActive(false);
        Time.timeScale = 1f;
    }
}

