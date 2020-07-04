using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Initialize : MonoBehaviour
{
    public UnityEvent action ;

    void Start()
    {
        if (action != null) action.Invoke();
    }
}
