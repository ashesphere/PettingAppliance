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
        if (target == other)
            isTargetInArea = true;
        var dt = other.GetComponent<DragTrigger>();
        if (dt)
        {
            dt.SetAreaTrigger(this);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (target == other)
            isTargetInArea = false;
            
    }
}
