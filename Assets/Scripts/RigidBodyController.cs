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

    public void SetPosition()
    {
        rgBody.position = isRelativePosition ? transform.TransformPoint(position) : position;
    }

    public void AddForceImpulse()
    {
        rgBody.AddForce(force, ForceMode.Impulse);
    }

    public void SetAngularVelocity()
    {
        rgBody.angularVelocity = angularVelocity;
    }

    public void SetVelocity()
    {
        rgBody.velocity = velocity;
    }
}
