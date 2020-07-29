using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseHolePatch : MonoBehaviour
{
    public GameObject mousePrefab;
    public float createMouseDelay = 1f;
    public UnityEvent onCreateMouse;
    public float mouseSpawnLeftRange = -2.5f;
    public float mouseSpawnRightRange = 2.5f;


    void OnTriggerEnter(Collider other)
    {
        var miniCat = other.GetComponent<MiniCat>();
        if (miniCat)
        {
            Invoke("CreateMouse", createMouseDelay);
            //foreach(Transform mt in transform)
            //    mt.SetParent(transform.parent);
            //gameObject.SetActive(false);
        }
    }

    public void CreateMouse()
    {
        //foreach (Transform t in transform) t.gameObject.SetActive(true);
        var g = Instantiate(mousePrefab, transform);
        g.transform.position = transform.position;
        
        if (onCreateMouse != null)
            onCreateMouse.Invoke();
    }
}
