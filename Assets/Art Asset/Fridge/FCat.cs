using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit raycastHit1;
        Physics.Raycast(ray, out raycastHit1, 2000, 0x01 << 9 | 0x01 << 8 | 0x01 << 0);
        RaycastHit raycastHit2;
        Physics.Raycast(ray, out raycastHit2, 2000, 0x01 << 10);
        if (raycastHit2.collider != null && raycastHit2.collider.tag == "Yugan" && raycastHit1.collider == GetComponent<MeshCollider>())
        {
            isOnCat = true;

        }
        else
        {
            isOnCat = false;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isOnCat)
            {
                if (!eventlock)
                {
                    eventlock = true;
                    //event
                    catHappy=true;
                    Destroy(yugan);
                    //happy 
                }
            }
        }
    }



    bool isOnCat = false;
    static int eventnum = 0;
    public static int GetEventNum()
    {
        return eventnum;
    }
    bool eventlock = false;
    float counter = 0;
    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.layer == 0x01 << 10)
        {
            Destroy(gameObject);
        }
    }
static bool catHappy=false;
public static bool GetCatHappy(){
    return catHappy;
}

public GameObject yugan;
}
