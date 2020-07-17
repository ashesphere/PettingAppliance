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
    bool isKinimatic;

    bool isBanned { get => !enabled; }
    public Rigidbody rgbody { get => GetComponent<Rigidbody>(); }
    public bool BackToOrigin { get => backToOrigin; set => backToOrigin = value; }
    Vector3 position 
    { 
        get => transform.position ; 
        set {
            if (rgbody) rgbody.MovePosition(value);
            else transform.position = value;
        }
    }

    void Start()
    {
        originalPosition = transform.localPosition;
        isKinimatic = rgbody.isKinematic;
    }

    void OnMouseDown()
    {
        if (isBanned) return;

        var camera = Camera.main;
        var ray = camera.ScreenPointToRay(Input.mousePosition);

        startDistance = Vector3.Distance(position, ray.origin);
        if (rgbody) rgbody.isKinematic = true;
    }

    void OnMouseDrag()
    {
        if (isBanned) return;

        var camera = Camera.main;
        var ray = camera.ScreenPointToRay(Input.mousePosition);
        position = ray.GetPoint(startDistance);
        
        if (changeCursor)
            CursorController.current.SetCursor(CursorType.Drag2);
    }

    void OnMouseUp()
    {
        if (isBanned) return;

        if (rgbody)
            rgbody.isKinematic = isKinimatic;
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

    public void SetOriginalPosition(Transform transform)
    {
        originalPosition = transform.position;
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

