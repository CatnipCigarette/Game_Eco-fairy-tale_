using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundControl : MonoBehaviour
{
    public GameObject[] itemPrefabs; // Массив префабов падающих предметов


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
            
        }


        if (collision.CompareTag("badItem"))
        {
            Destroy(collision.gameObject);
        }
    }
}
