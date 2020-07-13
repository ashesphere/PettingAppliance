using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyController : MonoBehaviour
{
    public Rigidbody rgBody ;
    public Vector3 position;
    public bool isRelativePosition;
    public Vector3 force;
    public Vector3 velocity;
    public Vector3 angularVelocity;
    public bool autoCloseKinimatic;

    public void SetPosition()
    {
        rgBody.position = isRelativePosition ? transform.TransformPoint(position) : position;
    }

    public void AddForceImpulse()
    {
        if (autoCloseKinimatic) rgBody.isKinematic = false;
        rgBody.AddForce(force, ForceMode.Impulse);
    }

    public void SetAngularVelocity()
    {
        if (autoCloseKinimatic) rgBody.isKinematic = false;
        rgBody.angularVelocity = angularVelocity;
    }

    public void SetVelocity()
    {
        if (autoCloseKinimatic) rgBody.isKinematic = false;
        rgBody.velocity = velocity;
    }
}
