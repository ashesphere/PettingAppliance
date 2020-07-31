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
    public GameObject effect;


    bool wasMouseDownOnThis = false;
    bool isMouseOnThis = true;
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
        
        currentTime += (isMouseMoving && isMouseOnThis) ? Time.fixedDeltaTime * 1.35f : 0;
        if (currentTime >= time)
        {
            if (action != null) action.Invoke();
            //currentTime = 0f;
            if (autoClose)
                gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (effect)
            effect.SetActive(wasMouseDownOnThis);
    }
    
    void LateUpdate()
    {
        if (!isActiveAndEnabled) return;
        lastMousePosition = Input.mousePosition;
    }

    void OnMouseExit()
    {
        if (!isActiveAndEnabled) return;
        //currentTime = 0f;
        isMouseOnThis = false;
        if (changeCursor && CursorController.current) {
            //Debug.Log("OnMouseExit");
            CursorController.current.SetCursor(CursorType.None);
        }
    }

    void OnMouseDown()
    {
        if (!isActiveAndEnabled) return;
        wasMouseDownOnThis = true;
        if (changeCursor && CursorController.current) {
            //Debug.Log("OnMouseDown");
            CursorController.current.SetCursor(CursorType.Hand);
        }
    }
    void OnMouseUp()
    {
        if (!isActiveAndEnabled) return;
        wasMouseDownOnThis = false;
        if (changeCursor && CursorController.current) {
            //Debug.Log("OnMouseUp");
            CursorController.current.SetCursor(CursorType.Drag1);
        }
    }
    void OnMouseEnter()
    {
        if (!isActiveAndEnabled) return;
        isMouseOnThis = true;
        if (changeCursor && CursorController.current) {
            if (Input.GetMouseButton(0) && wasMouseDownOnThis) {
                //Debug.Log("OnMouseEnter and MouseButtonOn");
                CursorController.current.SetCursor(CursorType.Hand);
            }
            else {
                //Debug.Log("OnMouseEnter and MouseButtonOff");
                CursorController.current.SetCursor(CursorType.Drag1);
            }
        }
    }
}
