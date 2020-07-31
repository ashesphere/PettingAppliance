using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickTrigger : MonoBehaviour
{
    public bool autoClose = true;
    public bool changeCursor = true;
    public UnityEvent action;
    public UnityEvent onMouseDown;

    bool isBanned { get => !enabled; }

    void Start()
    {
        
    }

    void OnMouseUp()
    {
        if (!enabled) return;
        if (action != null) action.Invoke();
        if (autoClose) {
            if (changeCursor && CursorController.current)
                CursorController.current.SetCursor(CursorType.None);
            gameObject.SetActive(false);
        }
    }
    void OnMouseDown()
    {
        if (!enabled) return;
        if (onMouseDown != null)onMouseDown.Invoke();
        if (changeCursor && CursorController.current)
            CursorController.current.SetCursor(CursorType.Click2);
    }

    void OnMouseEnter()
    {
        if (!enabled) return;
        if (changeCursor && CursorController.current)
            CursorController.current.SetCursor(CursorType.Click1);
    }

    void OnMouseExit()
    {
        if (!enabled) return;
        if (changeCursor && CursorController.current)
            CursorController.current.SetCursor(CursorType.None);
    }
}
