using UnityEngine;
using System.Collections.Generic;

public class ItemController : MonoBehaviour
{
    public GameObject[] itemPrefabs; // ������ �������� �������� ���������
    public float spawnInterval = 2f; // �������� ��������� ����� ���������
    public float minXPosition = -5f; // ����������� ������� �� ��� X
    public float maxXPosition = 5f; // ������������ ������� �� ��� X
    public float spawnHeight = 10f; // ������, �� ������� ����� ���������� ��������

    private List<GameObject> spawnedItems = new List<GameObject>();

    private void Start()
    {
        InvokeRepeating("SpawnItem", spawnInterval, spawnInterval);
    }

    private void SpawnItem()
    {
        int randomIndex = Random.Range(0, itemPrefabs.Length); // ��������� ������ �� ������� ��������
        float randomX = Random.Range(minXPosition, maxXPosition);
        Vector3 spawnPosition = new Vector3(randomX, spawnHeight, transform.position.z);
        GameObject newItem = Instantiate(itemPrefabs[randomIndex], spawnPosition, Quaternion.identity);
        spawnedItems.Add(newItem);
        Destroy(newItem, 10f); // ���������� ������� ����� 10 ������
    }

    public void ClearSpawnedItems()
    {
        foreach (GameObject item in spawnedItems)
        {
            Destroy(item);
        }
        spawnedItems.Clear(); // �������� ������ ��������� ���������
    }
}
