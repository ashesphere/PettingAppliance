using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHolePatch : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        var miniCat = other.GetComponent<MiniCat>();
        if (miniCat)
        {
            CreateMouse();
            transform.DetachChildren();
            gameObject.SetActive(false);
        }
    }

    void CreateMouse()
    {
        foreach (Transform t in transform) t.gameObject.SetActive(true);
    }
}
