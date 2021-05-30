public interface IState {
    void OnInit();
    void OnSet();
    void OnReset();
    void OnUpdate();
}