using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragTrigger : BasicTrigger
{
    public bool backToOrigin = true;
    public bool changeCursor = true;

    float startDistance;
    Vector3 originalPosition;
    AreaTrigger area;

    public Rigidbody rgbody { get => GetComponent<Rigidbody>(); }
    public bool BackToOrigin { get => backToOrigin; set => backToOrigin = value; }

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    void OnMouseDown()
    {
        if (isBanned) return;

        var camera = Camera.main;
        var ray = camera.ScreenPointToRay(Input.mousePosition);

        startDistance = Vector3.Distance(transform.position, ray.origin);
        if (rgbody) rgbody.isKinematic = true;
    }

    void OnMouseDrag()
    {
        if (isBanned) return;

        var camera = Camera.main;
        var ray = camera.ScreenPointToRay(Input.mousePosition);
        transform.position = ray.GetPoint(startDistance);
        
        if (changeCursor)
            CursorController.current.SetCursor(CursorType.Drag2);
    }

    void OnMouseUp()
    {
        if (isBanned) return;

        if (rgbody)
            rgbody.isKinematic = false;
        if (area)
        {
            if (area.isTargetInArea && area.target == GetComponent<Collider>() && area.onTargetDrop != null)
            {
                area.onTargetDrop.Invoke();
                if (area.autoClose)
                    area.gameObject.SetActive(false);
            }
            else if (backToOrigin)
                BackToOriginalPosition();
        }
        else if (backToOrigin)
            BackToOriginalPosition();
    }

    public void BackToOriginalPosition()
    {
        transform.localPosition = originalPosition;
    }

    public void SetAreaTrigger(AreaTrigger a)
    {
        area = a;
    }
    
    void OnMouseEnter()
    {
        
        if (isBanned) return;

        if (changeCursor)
            CursorController.current.SetCursor(CursorType.Drag1);
    }

    void OnMouseExit()
    {
        
        if (isBanned) return;
        
        if (changeCursor)
            CursorController.current.SetCursor(CursorType.None);
    }
}

