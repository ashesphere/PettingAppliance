using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHolePatch : MonoBehaviour
{
public AudioClip AO;
public AudioSource source;
    void OnTriggerEnter(Collider other)
    {
        var miniCat = other.GetComponent<MiniCat>();
        if (miniCat)
        {
            CreateMouse();
            foreach(Transform mt in transform)
                mt.SetParent(transform.parent);
            gameObject.SetActive(false);
            source.PlayOneShot(AO,1F);
        }
    }

    void CreateMouse()
    {
        foreach (Transform t in transform) t.gameObject.SetActive(true);
    }
}
