using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScrollTrigger : MonoBehaviour
{
    public bool autoClose = true;
    public bool changeCursor = true;
    public UnityEvent action;

    void Update()
    {
        var mouseScrollDelta = Input.mouseScrollDelta;
        if (changeCursor)
            CursorController.current.SetCursor(CursorType.Scroll);
        if (mouseScrollDelta.y != 0)
        {
            if (action != null)
                action.Invoke();
            if (autoClose) gameObject.SetActive(false);
            if (changeCursor)
                CursorController.current.SetCursor(CursorType.None);
        }
    }
}
