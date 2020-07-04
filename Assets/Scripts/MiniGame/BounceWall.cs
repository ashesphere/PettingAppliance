using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceWall : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        var miniCat = other.GetComponent<MiniCat>();
        if (miniCat)
        {
            var rg = other.GetComponent<Rigidbody>();
            var inVelocity = rg.velocity;
            var selfVector = transform.right;
            var targetVelocity = GetReflectedDir(inVelocity, selfVector).normalized * inVelocity.magnitude;

            miniCat.Run(targetVelocity);
        }
    }

    public static Vector3 GetReflectedDir(Vector3 v1, Vector3 n)
    {
        return v1 - 2 * Vector3.Dot(v1, n) * n;
    }
}
