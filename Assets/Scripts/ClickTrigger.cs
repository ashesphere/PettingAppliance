using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickTrigger : MonoBehaviour
{
    public bool autoClose = true;
    public bool changeCursor = true;
    public UnityEvent action;

    bool isBanned { get => !enabled; }

    void Start()
    {
        
    }

    void OnMouseDown()
    {
        if (!enabled) return;
        if (action != null) action.Invoke();
        if (autoClose) gameObject.SetActive(false);
    }

    void OnMouseEnter()
    {
        if (!enabled) return;
        if (changeCursor && CursorController.current)
            CursorController.current.SetCursor(CursorType.Click2);
    }

    void OnMouseExit()
    {
        if (!enabled) return;
        if (changeCursor && CursorController.current)
            CursorController.current.SetCursor(CursorType.None);
    }
}
