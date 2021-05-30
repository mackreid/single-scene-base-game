using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State<T> : ScriptableObject, IState where T : UIState {
    public UIState UIPrefab;
    public static T UI {private set; get;}

    public virtual void OnInit() {
        UI = Instantiate(UIPrefab) as T;
        UI.OnInit();
    }
    public virtual void OnSet() {
        UI.OnShow();
    }
    public virtual void OnReset() {
        UI.OnHide();
    }
    public virtual void OnUpdate() {
        
    }
}
