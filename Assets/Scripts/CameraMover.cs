using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CameraMover : MonoBehaviour
{
    public float maxMoveTime = 2f;
    public float speed = 1f;
    public bool autoClose = true;
    public UnityEvent nextAction;

    public static bool isPauseByButton;
    
    IEnumerator Start()
    {
        yield return FindObjectOfType<PlayerCamera>().LerpTo(transform, maxMoveTime, speed);
        if (!autoClose) 
        {
            TopViewPlayButton.current.Open(true);
            isPauseByButton = true;
            yield return new WaitUntil(() => !isPauseByButton);
            TopViewPlayButton.current.Open(false);
        }
        if (nextAction != null) nextAction.Invoke();
        if (autoClose) gameObject.SetActive(false);
    }
/*
#if UNITY_EDITOR

    static Vector3 originalPosition;
    static Quaternion originalRotation;
    bool isSelected;

    void OnEnable()
    {
        if (Application.isPlaying)
            return;
        originalPosition = Camera.main.transform.position;
        originalRotation = Camera.main.transform.rotation;
        Selection.selectionChanged += OnSelectionChange;
        isSelected = true;
    }

    void Update()
    {
        if (Application.isPlaying)
            return;
        if (isSelected)
            Camera.main.transform.SetPositionAndRotation(transform.position, transform.rotation);
    }

    void OnDisable()
    {
        if (Application.isPlaying)
            return;
        Camera.main.transform.SetPositionAndRotation(originalPosition, originalRotation);
    }

    void OnSelectionChange()
    {
        if (Application.isPlaying)
            return;
        if (Selection.activeGameObject != gameObject)
        {
            isSelected = false;
            Camera.main.transform.SetPositionAndRotation(originalPosition, originalRotation);
        }
        else
        {isSelected = true; }
    }
#endif
*/
}
