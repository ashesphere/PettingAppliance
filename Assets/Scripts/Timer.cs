using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public float time = 2f;
    public bool autoClose = true;
    public UnityEvent action;

    bool isUsed = false;

    void OnEnable()
    {
        if (isUsed) StartCoroutine(Start());
    }

    IEnumerator Start()
    {
        isUsed = true;
        yield return new WaitForSeconds(time);
        if (action != null) action.Invoke();
        if (autoClose) gameObject.SetActive(false);
    }
}
