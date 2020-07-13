using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class MaterialColorController : MonoBehaviour
{
    public Color color;

    void Update()
    {
        var rd = GetComponent<MeshRenderer>();
        var mat = rd.sharedMaterial;
        mat.color = color;
    }
}
