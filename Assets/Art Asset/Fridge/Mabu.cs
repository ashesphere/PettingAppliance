using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mabu : MonoBehaviour
{
 
    void Start()
    {
        Init();
    }
    RaycastHit rh;
    void Update()
    {
        Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
        //Ray ray=new Ray(Camera.main.transform.position,Input.mousePosition);
        Physics.Raycast(ray, out rh,1000);
        //Debug.Log(rh.collider.tag);
    }

    bool canUse=false;

    public void Init(){
        canUse=true;
    }
}
