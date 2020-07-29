using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AreaTrigger : MonoBehaviour
{
    public bool autoClose = true;
    public Collider target;
    public UnityEvent onTargetDrop;

    public bool isTargetInArea;

    void OnTriggerEnter(Collider other)
    {
        if (!enabled) return;
        if (target == other)
            isTargetInArea = true;
        var dt1 = other.GetComponent<DragTrigger>();
        var dt2 = other.GetComponent<DragTriggerNew>();
        if (dt1)
        {
            dt1.SetAreaTrigger(this);
        }
        if (dt2)
        {
            dt2.SetAreaTrigger(this);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!enabled) return;
        if (target == other)
            isTargetInArea = false;
            
    }
}
