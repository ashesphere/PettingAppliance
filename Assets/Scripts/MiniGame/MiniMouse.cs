using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMouse : MonoBehaviour
{
    public static List<MiniMouse> all = new List<MiniMouse>();
    public static float maxDistance = 5f;

    public float moveSpeed = 5f;

    float currentDistance;
    float direction = 1f;

    void OnEnable()
    {
        all.Add(this);
    }

    void OnDisable()
    {
        all.Remove(this);
    }

    void Start()
    {
        currentDistance = Random.Range(-maxDistance/2f, maxDistance/2f);
    }

    void FixedUpdate()
    {
        var deltaD = Time.fixedDeltaTime * maxDistance * direction;
        currentDistance += deltaD;
        transform.localPosition += new Vector3(deltaD,0,0);
        if (Mathf.Abs(currentDistance) >= maxDistance)
        {
            direction *= -1f;
            currentDistance = 0f;
        }

    }

    public void Kill()
    {
        gameObject.SetActive(false);
    }
}
