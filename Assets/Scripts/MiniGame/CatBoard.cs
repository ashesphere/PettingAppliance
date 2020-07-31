using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBoard : MonoBehaviour
{
    public GameObject aimor;

    void OnTriggerEnter(Collider other)
    {
        var miniCat = other.GetComponent<MiniCat>();
        if (miniCat)
        {
            miniCat.Stop();
            miniCat.transform.SetParent(transform);
            miniCat.transform.localPosition=new Vector3(miniCat.transform.localPosition.x,2.8f,miniCat.transform.localPosition.z);
            miniCat.EnableGravity(false);

            var apos = aimor.transform.position;
            apos.x = miniCat.transform.position.x;
            aimor.transform.position = apos;
        }
    }
}
