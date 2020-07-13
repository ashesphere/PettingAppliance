using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeController : MonoBehaviour
{
    public Transform target;
    public float deltaSize;

    public void AddDeltaSize()
    {
        if (!enabled) return;
        target.localScale += deltaSize * Vector3.one;
    }
}
