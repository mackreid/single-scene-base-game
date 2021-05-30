using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool {
    #region Public Variables
    public string tag;
    public GameObject prefab;
    public int size;
    public Transform parent = null;
    #endregion  
}

public class ObjectPool : Singleton<ObjectPool> {

    #region Public Variables
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    #endregion

    #region Public Methods
    public void InitPool() {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools) {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for(int i = 0; i < pool.size; i++) {
                GameObject obj = Instantiate(pool.prefab);
                obj.transform.SetParent(pool.parent ?? null, false);
                IPooledObject p = obj.GetComponent<IPooledObject>();
                p.OnObjectPooled(pool.tag);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject GetObjectFromPool(string tag) {
        if(!poolDictionary.ContainsKey(tag)) {
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        return objectToSpawn;
    }

    public void PutObjectBackIntoPool(string tag, GameObject obj) {
        poolDictionary[tag].Enqueue(obj);
    }
    #endregion

    protected override void Awake() {
        base.Awake();
        InitPool();
    }
}
