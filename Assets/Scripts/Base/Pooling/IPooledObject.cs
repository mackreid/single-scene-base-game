public interface IPooledObject {
    void OnObjectPooled(string tag);
    void OnObjectSpawn();
    void OnObjectReset();
}
