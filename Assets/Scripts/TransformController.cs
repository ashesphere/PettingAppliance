using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformController : MonoBehaviour
{
    public void SetPosition(Transform t)
    {
        transform.position = t.position;
    }

    public void SetRotation(Transform t)
    {
        transform.rotation = t.rotation;
    }

    public void SetScale(Transform t)
    {
        transform.localScale = t.localScale;
    }

    public void SetAll(Transform t)
    {
        SetPosition(t);
        SetRotation(t);
        SetScale(t);
    }
}
