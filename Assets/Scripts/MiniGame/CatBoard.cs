using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBoard : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        var miniCat = other.GetComponent<MiniCat>();
        if (miniCat)
        {
            miniCat.Stop();
            miniCat.transform.SetParent(transform);
        }
    }
}
