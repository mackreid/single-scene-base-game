using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class StateType {
    public ScriptableObject state;
    public string tag;
}

public class Manager : Singleton<Manager> {
    public StateType[] allStates;
    public IState CurrentState;
    public void SetStateFromTag(string tag) {
        if(CurrentState != null) CurrentState.OnReset();
        foreach(StateType s in allStates) {
            if(s.tag == tag) CurrentState = s.state as IState;
        }
        Debug.Log(CurrentState);
        CurrentState.OnSet();        
    }
    private void InitAllStates() {
        for(int i = 0; i < allStates.Length; i++) {
            IState s = allStates[i].state as IState;
            s.OnInit();
        }
    }
    private void Update() {
        if(CurrentState != null) CurrentState.OnUpdate();
    }
    private void Start() {
        ObjectPool.Instance.InitPool();
        InitAllStates();
        SetStateFromTag("Menu");
    }
}
