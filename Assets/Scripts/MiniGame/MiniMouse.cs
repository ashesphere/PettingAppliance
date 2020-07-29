using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMouse : MonoBehaviour
{
    public static List<MiniMouse> all = new List<MiniMouse>();

    //public static float maxDistance = 2f;
    public float maxDistance;
    public bool isInitMouse = false;

    public float moveSpeed;

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
        //currentDistance = Random.Range(-randomRange/2f, randomRange/2f);
        
        currentDistance = 0;
        if (!isInitMouse) {
            var patch = GetComponentInParent<MouseHolePatch>();
            if (patch == null) return;
            transform.localPosition += new Vector3(Random.Range(patch.mouseSpawnLeftRange, patch.mouseSpawnRightRange), 0, 0);
        }
    }

    void FixedUpdate()
    {
        var deltaD = Time.fixedDeltaTime * moveSpeed * direction;
        currentDistance += deltaD;
        transform.localPosition += new Vector3(deltaD,0,0);
        if (currentDistance <= -maxDistance)
        {
            direction *= -1f;
            //currentDistance = 0f;
        } else if (currentDistance >= maxDistance)
        {
            direction *= -1f;
            //currentDistance = 0f;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        var wall = other.GetComponent<BounceWall>();
        if (wall != null && wall.tag == "WallLeft" && direction == -1){
            Debug.Log("Hit Left Wall!");
            direction *= -1f;
        }
        if (wall != null && wall.tag == "WallRight" && direction == 1){
            Debug.Log("Hit Right Wall!");
            direction *= -1f;
        }
    }

    public void Kill()
    {
        //gameObject.SetActive(false);、
        Destroy(gameObject);
    }
}
