using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMilk : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 lastMousePosition;
    void Start()
    {
        eventnum = 0;
        lastMousePosition = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit raycastHit1;
        //Physics.Raycast(ray, out raycastHit1, 2000, 0x01<<9 |0x01<<8 |0x01<<0);
        Physics.Raycast(ray, out raycastHit1, 2000, 0b1111111011);
        RaycastHit raycastHit2;
        Physics.Raycast(ray, out raycastHit2, 2000, 0x01 << 10);
        
        bool isMouseMoving = lastMousePosition != Input.mousePosition;
        if (raycastHit2.collider != null && raycastHit2.collider.tag == "Mabu" && isMouseMoving
                && raycastHit1.collider == GetComponent<MeshCollider>())
        {
            counter += Time.deltaTime;
            Vector3 colorv= Vector3.Lerp(Vector3.zero,Vector3.one,counter);
            GetComponent<MeshRenderer>().material.SetColor("_Color",new Color(colorv.x,colorv.y,colorv.z));
            if (counter > 1)
            {

                if (!eventlock)
                {
                    eventlock = true;
                    //event
                   eventnum++;
                  Debug.Log(eventnum);
                }
            }
        }
        
        lastMousePosition = Input.mousePosition;
    }

    static int eventnum=0;
    public static int GetEventNum(){
        return eventnum;
    }
    bool eventlock = false;
    float counter = 0;
    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.layer == 0x01<<10)
        {
            Destroy(gameObject);
        }
    }
}
