using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class MermTrigger : MonoBehaviour
{
    public GameObject text; 
    public Flowchart flowchart;

    private bool isNear = false;

    private void Update()
    {
        if (isNear && Input.GetKeyDown(KeyCode.E))
        {
            LoadDilog();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mermaid")) 
        {
            isNear = true;
            text.SetActive(true); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Mermaid")) 
        {
            isNear = false;
            text.SetActive(false); 
        }
    }

    public void LoadDilog()
    {
        flowchart.ExecuteBlock("MermaidDialog"); 
        text.SetActive(false);
    }

}

