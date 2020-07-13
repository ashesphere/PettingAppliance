using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionController : MonoBehaviour
{
    public Transform target;
    public Vector3 position;

    public void SetPosition()
    {
        if (!enabled) return;
        target.position = transform.position + position;
    }
}
