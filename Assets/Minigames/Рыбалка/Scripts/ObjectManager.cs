using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private List<GameObject> destroyedObjects = new List<GameObject>();

    public void AddDestroyedObject(GameObject obj)
    {
        destroyedObjects.Add(obj);
    }

    public void RestoreObjects()
    {
        foreach (GameObject obj in destroyedObjects)
        {
            Instantiate(obj, obj.transform.position, obj.transform.rotation);
        }
        destroyedObjects.Clear();
    }
}
