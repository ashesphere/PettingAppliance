using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FondleTrigger : MonoBehaviour
{
    public float time = 2f;
    public bool autoClose = true;
    public bool changeCursor = true;
    public UnityEvent action;

    [SerializeField]float currentTime = 0f;
    Vector3 lastMousePosition;

    void OnEnable()
    {
        //if (!isActiveAndEnabled) return;
        currentTime = 0f;
    }

    void OnMouseDrag()
    {
        if (!isActiveAndEnabled) return;
        bool isMouseMoving = lastMousePosition != Input.mousePosition;
        currentTime += isMouseMoving ? Time.fixedDeltaTime * 1.35f : 0;
        if (currentTime >= time)
        {
            if (action != null) action.Invoke();
            currentTime = 0f;
            if (autoClose)
                gameObject.SetActive(false);
        }
    }

    void LateUpdate()
    {
        if (!isActiveAndEnabled) return;
        lastMousePosition = Input.mousePosition;
    }

    void OnMouseExit()
    {
        if (!isActiveAndEnabled) return;
        currentTime = 0f;
        if (changeCursor && CursorController.current)
            CursorController.current.SetCursor(CursorType.None);
    }
    
    void OnMouseEnter()
    {
        if (!isActiveAndEnabled) return;
        if (changeCursor && CursorController.current)
            CursorController.current.SetCursor(CursorType.Click2);
    }

}
