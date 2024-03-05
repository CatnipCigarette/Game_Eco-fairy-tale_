using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Text itemCounterText; // ��������� ��������� ��� ����������� ���������� ��������� ���������

    public GameObject Win;

    private int itemsFound; // ���������� ��������� ���������

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        itemsFound = 0;
        UpdateItemCounterText();
    }

    public void ItemFound()
    {
        itemsFound++;
        UpdateItemCounterText();

        if (itemsFound == 12)
        {
            Win.SetActive(true);
        }
    }

    private void UpdateItemCounterText()
    {
        itemCounterText.text = "������� ���������: " + itemsFound.ToString() + "/12";
    }
}
