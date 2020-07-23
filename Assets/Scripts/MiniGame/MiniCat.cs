﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MiniCat : MonoBehaviour
{
    public bool isStopped = true;
    public UnityEvent onCatchMice;

    Rigidbody rgbody { get => GetComponent<Rigidbody>(); }

    public void Stop()
    {
        rgbody.velocity = Vector2.zero;
        isStopped = true;
    }

    public void Run(Vector3 v)
    {
        rgbody.velocity = v;
        //transform.up = v;
        isStopped = false;
        transform.SetParent(null);
        EnableGravity(true);
    }

    public void EnableGravity(bool e)
    {
        GetComponent<ConstantForce>().enabled = e;
    }

    void OnTriggerEnter(Collider other)
    {
        var miniMice = other.GetComponent<MiniMouse>();
        if (miniMice)
        {
            miniMice.Kill();
            if (onCatchMice != null)
                onCatchMice.Invoke();
        }
    }
}
