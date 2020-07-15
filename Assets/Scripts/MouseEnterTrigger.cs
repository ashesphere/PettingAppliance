using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseEnterTrigger : MonoBehaviour
{
    public bool changeCursor = true;
    public CursorType cursor;
    public UnityEvent onEnter;
    public UnityEvent onExit;

    void OnMouseEnter()
    {
        if (!isActiveAndEnabled) return;
        if (changeCursor) CursorController.current.SetCursor(cursor);
        if (onEnter != null) onEnter.Invoke();
    }

    void OnMouseExit()
    {
        if (!isActiveAndEnabled) return;
        if (changeCursor) CursorController.current.SetCursor(CursorType.None);
        if (onExit != null) onExit.Invoke();
    }
}
