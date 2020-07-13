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
            foreach(Transform mt in transform)
                mt.SetParent(transform.parent);
            gameObject.SetActive(false);
        }
    }

    void CreateMouse()
    {
        foreach (Transform t in transform) t.gameObject.SetActive(true);
    }
}
