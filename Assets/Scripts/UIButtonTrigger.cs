using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonTrigger : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    public bool changeCursor = true;

    public void OnPointerEnter(PointerEventData data)
    {
        if (changeCursor)
            CursorController.current.SetCursor(CursorType.Click1);
    }

    public void OnPointerExit(PointerEventData data)
    {
        if (changeCursor)
            CursorController.current.SetCursor(CursorType.None);
    }
}
