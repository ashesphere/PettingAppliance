using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMouse : MonoBehaviour
{
    public static List<MiniMouse> all = new List<MiniMouse>();

    void OnEnable()
    {
        all.Add(this);
    }

    void OnDisable()
    {
        all.Remove(this);
    }

    public void Kill()
    {
        gameObject.SetActive(false);
    }
}
