using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIState : MonoBehaviour, IUIState {
    private Canvas Canvas;
    public virtual void OnShow() {
        Canvas.enabled = true;
    }
    public virtual void OnHide() {
        Canvas.enabled = false;
    }
    public virtual void OnInit() {
        Canvas = GetComponent<Canvas>();
        OnHide();
    }
}
