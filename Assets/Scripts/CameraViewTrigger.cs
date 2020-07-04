using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraViewTrigger : MonoBehaviour
{
    public bool autoClose = true;
    public UnityEvent action;

    IEnumerator Start()
    {
        PlayerCamera.current.OpenScroll(true);
        yield return new WaitUntil(()=>PlayerCamera.current.IsMin);
        if (action != null)
            action.Invoke();
        if (autoClose)
            gameObject.SetActive(false);
    }

}
