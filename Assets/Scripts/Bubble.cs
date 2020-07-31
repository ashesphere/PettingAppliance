using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float time = 8f;
    public bool onlyOpenOnce = true;

    bool isOpened;
    
    IEnumerator Start()
    {
        isOpened = true;
        if (time >= 0f)
        {
            yield return new WaitForSeconds(time);
            gameObject.SetActive(false);
        }
    }

    public void Open()
    {
        if (!isOpened || ! onlyOpenOnce)
            gameObject.SetActive(true);
    }
}
