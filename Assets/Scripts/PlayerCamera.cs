using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : SingleTon<PlayerCamera>
{
    public float minFov = 20f;
    public float maxFov = 70f;
    public float sensitivity = 20f;

    float originalFov;
    bool isScrollOpened;

    float currentFOV {get => Camera.main.fieldOfView; set => Camera.main.fieldOfView = value;}
    Vector3 cameraPosition {
        get => Camera.main.transform.position;
        set => Camera.main.transform.position = value;
    }    
    Vector3 cameraEulerAngles{
        get => Camera.main.transform.eulerAngles;
        set => Camera.main.transform.eulerAngles = value;
    }
    Quaternion cameraRotation{
        get => Camera.main.transform.rotation;
        set => Camera.main.transform.rotation = value;
    }

    void Update()
    {
        if (!isScrollOpened) return;

        float fov = currentFOV;
        fov -= Input.mouseScrollDelta.y * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        currentFOV = fov;
    }

    public void OpenScroll(bool o)
    {
        isScrollOpened = o;
        if (isScrollOpened)
            originalFov = currentFOV;
    }

    public IEnumerator FOVBackToOriginRoutine()
    {
        isScrollOpened = false;
        while(Mathf.Abs(currentFOV - originalFov) > 0.02f)
        {
            float d = Mathf.Abs(currentFOV - originalFov);
            currentFOV = d > 1f ?
                Mathf.Lerp(currentFOV, originalFov, Time.deltaTime * 2f) : 
                Mathf.MoveTowards(currentFOV, originalFov, Time.deltaTime * 2f);
            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator LerpTo(Transform t, float maxTime = 2f, float speed = 1f)
    {
        float time = maxTime;
        while(Vector3.Distance(t.position, cameraPosition) > 0.02f
            || Vector3.Distance(t.eulerAngles, cameraEulerAngles) > 0.02f
            && time > 0f)
        {
            float d = Vector3.Distance(t.position, cameraPosition);
            cameraPosition = d > 0.001f ?
                Vector3.Lerp(cameraPosition, t.position, Time.deltaTime * 2f * speed) : 
                Vector3.MoveTowards(cameraPosition, t.position, Time.deltaTime * 2f* speed);
            float e = Vector3.Distance(t.eulerAngles, cameraEulerAngles);
            /*
            cameraEulerAngles = d > 1f ?
                Vector3.Lerp(cameraEulerAngles, t.eulerAngles, Time.deltaTime * 2f* speed) : 
                Vector3.Lerp(cameraEulerAngles, t.eulerAngles, Time.deltaTime * 2f* speed);
            */
            cameraRotation = e > 0.001f ?
                Quaternion.Lerp(cameraRotation, t.rotation, Time.deltaTime * 2f * speed):
                Quaternion.Lerp(cameraRotation, t.rotation, Time.deltaTime * 2f * speed);
                //Vector3.MoveTowards(cameraEulerAngles, t.eulerAngles, Time.deltaTime * 20f * speed);
            time -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
    
    public void CameraFOVBackToOrigin()
    {
        StartCoroutine(FOVBackToOriginRoutine());
    }

    public bool IsMin { get => Camera.main.fieldOfView <= minFov; }
    public bool IsMax { get => Camera.main.fieldOfView >= maxFov; }
}
