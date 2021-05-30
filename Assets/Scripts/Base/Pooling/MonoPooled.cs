using UnityEngine;
public class MonoPooled<T> : MonoBehaviour, IPooledObject where T : MonoBehaviour {
    private string _PooledTag;
    public virtual void OnObjectPooled(string tag) {
        _PooledTag = tag;
        gameObject.SetActive(false);
    }
    public virtual void OnObjectReset() {
        ObjectPool.Instance.PutObjectBackIntoPool(_PooledTag, gameObject);
        gameObject.SetActive(false);
    }
    public virtual void OnObjectSpawn() {
        gameObject.SetActive(true);
    }
}
