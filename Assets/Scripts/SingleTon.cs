using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTon<T> : MonoBehaviour where T:MonoBehaviour
{
    static T _current;
    public static T current{
        get{
            if (!_current) _current = FindObjectOfType<T>();
            return _current;
        }
    }
}
