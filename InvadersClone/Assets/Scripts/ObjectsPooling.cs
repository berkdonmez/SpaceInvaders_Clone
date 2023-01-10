using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPooling : MonoBehaviour
{
    private Queue<GameObject> pooledObjects;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] int poolSize;

    void Awake()
    {
        pooledObjects = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            pooledObjects.Enqueue(obj);
        }
    }

    public GameObject GetPooledObjects()
    {
        GameObject obj = pooledObjects.Dequeue();
        obj.SetActive(true);
        pooledObjects.Enqueue(obj);
        return obj;
    }
}
