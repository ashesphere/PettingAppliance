﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragTriggerNew : BasicTrigger
{
    public bool backToOrigin = true;
    public bool changeCursor = true;

    float startDistance;
    Vector3 originalPosition;
    public float radius;
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
        if(rgbody)isKinimatic = rgbody.isKinematic;
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
        
        RaycastHit raycastHit;
        //Physics.Raycast(ray, out raycastHit,2000,0x01<<9 |0x01<<8 |0x01<<0);
        Physics.Raycast(ray, out raycastHit, 2000, 0b1111111011);

        position = raycastHit.point-Vector3.Normalize(raycastHit.point-camera.transform.position)*radius;//ray.GetPoint(startDistance);
        
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

