using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraScrollViewTrigger : MonoBehaviour
{

    public bool autoClose = true;
    public bool changeCursor = true;
    [Range(0.1f,10f)]public float sensitive = 5f;
    public Transform target;
    public UnityEvent onCloseToTarget;

    (Vector3 p, Quaternion q) originalPQ;
    float mouseScrollAmount;

    void Start()
    {
        var cam = Camera.main.transform;
        originalPQ.p = cam.position;
        originalPQ.q = cam.rotation;
    }

    void FixedUpdate()
    {
        var cam = Camera.main.transform;
        if (!cam) return;
        
        if (changeCursor)
            CursorController.current.SetCursor(CursorType.Scroll);

        mouseScrollAmount += Input.mouseScrollDelta.y * Time.deltaTime * sensitive;
        
        float closeToTargetRate = Mathf.Clamp01(mouseScrollAmount);
        cam.transform.position = Vector3.Lerp(originalPQ.p, target.position, closeToTargetRate);
        cam.transform.rotation = Quaternion.Lerp(originalPQ.q, target.rotation, closeToTargetRate);
        if (closeToTargetRate >= 0.99f)
        {
            if (onCloseToTarget != null) onCloseToTarget.Invoke();
            if (autoClose) {
                gameObject.SetActive(false);
                if (changeCursor)
                    CursorController.current.SetCursor(CursorType.None);
            }
        }
    }
}
