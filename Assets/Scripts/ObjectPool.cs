using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Singleton;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool = 1;

    private void Awake() {
        Singleton = this;
    }

    private void Start() {
        pooledObjects = new List<GameObject>();
        for(int i = 0; i < amountToPool; i++)
            createNewObject();
    }

    public GameObject GetPooledObject ()
    {
        for(int i = 0; i < pooledObjects.Count; i++)
        {
            if(!pooledObjects[i].activeInHierarchy){
                return pooledObjects[i];
            }
        }
        return createNewObject();
    }

    private GameObject createNewObject()
    {
        GameObject instance = Instantiate(objectToPool);
        instance.SetActive(false);
        pooledObjects.Add(instance);
        return instance;
    }
}
