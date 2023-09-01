using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string nameKey;
        public GameObject prefab;
        public int size;
    }
    public static ObjectPoolManager instance;
    public List<Pool> pools;
    private Dictionary<string, Queue<GameObject>> objectPools = new Dictionary<string, Queue<GameObject>>();
    private void Awake()
    {
        instance = this;
        foreach(Pool currentPool in pools)
        {
            Queue<GameObject> newQueu = new Queue<GameObject>();
            for(int i=0; i<currentPool.size; i++)
            {
                GameObject obj = Instantiate(currentPool.prefab);
                obj.SetActive(true);
                newQueu.Enqueue(obj);
            }
            objectPools.Add(currentPool.nameKey, newQueu);
        }
    }
    public GameObject GetFromPool(string keyName)
    {
        if(objectPools.ContainsKey(keyName) && objectPools[keyName].Count > 0)
        {
            GameObject obj = objectPools[keyName].Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }
        return null;
    }
    public void ReturnToPool(string key, GameObject gameObject)
    {
        if(objectPools.ContainsKey(key))
        {
            objectPools[key].Enqueue(gameObject);
        }
    }
}
