using UnityEngine;
using System.Collections.Generic;

public class ItemController : MonoBehaviour
{
    public GameObject[] itemPrefabs; // Массив префабов падающих предметов
    public float spawnInterval = 2f; // Интервал появления новых предметов
    public float minXPosition = -5f; // Минимальная позиция по оси X
    public float maxXPosition = 5f; // Максимальная позиция по оси X
    public float spawnHeight = 10f; // Высота, на которой будут появляться предметы

    private List<GameObject> spawnedItems = new List<GameObject>();

    private void Start()
    {
        InvokeRepeating("SpawnItem", spawnInterval, spawnInterval);
    }

    private void SpawnItem()
    {
        int randomIndex = Random.Range(0, itemPrefabs.Length); // Случайный индекс из массива префабов
        float randomX = Random.Range(minXPosition, maxXPosition);
        Vector3 spawnPosition = new Vector3(randomX, spawnHeight, transform.position.z);
        GameObject newItem = Instantiate(itemPrefabs[randomIndex], spawnPosition, Quaternion.identity);
        spawnedItems.Add(newItem);
        Destroy(newItem, 10f); // Уничтожить предмет через 10 секунд
    }

    public void ClearSpawnedItems()
    {
        foreach (GameObject item in spawnedItems)
        {
            Destroy(item);
        }
        spawnedItems.Clear(); // Очистить список созданных предметов
    }
}
