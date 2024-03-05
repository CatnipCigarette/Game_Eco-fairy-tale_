using UnityEngine;
using UnityEngine.UI;

public class ActivateMiniGame : MonoBehaviour
{
    public GameObject MiniGameContainer;
    public GameObject Rule;

    private void Start()
    {
        // ������� ������ �� ���� ��� ������ ��������
        Button button = GetComponent<Button>();

        // ��������� ���������� ������� ������� �� ������
        button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        // ������ MiniGameContainer ��������
        MiniGameContainer.SetActive(true);
        Rule.SetActive(false);
    }
}
