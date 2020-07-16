using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class HariDryer : MonoBehaviour
{

    IEnumerator Start()
    {
        //播放撞墙动画+音效

        GetComponent<Animator>().Play("Knock");
        yield return new WaitForSeconds(0);
    }

    void Update()
    {
        //if(CameraMover.isPauseByButton)
        {

            if (!finishStageOne)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(r, out rh, Mathf.Infinity))
                    {
                        if (rh.collider.gameObject == body || rh.collider.gameObject == handle)

                        {
                            finishStageOne = true;
                            //停止撞墙动画，换眼睛，开启其他特效

                            GetComponent<PlayableDirector>().playableGraph.GetRootPlayable(0).Pause();
                        }
                    }
                }
            }
            else
            {
                if (!finishStageTwo)
                {
                    if (Input.GetMouseButton(0))
                    {
                        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
                        if (Physics.Raycast(r, out rh, Mathf.Infinity))
                        {
                            if (rh.collider.gameObject == body)

                            {


                                if (rh.point != lastDisplacement)
                                {
                                    lastDisplacement = rh.point;


                                    counter += Time.deltaTime;
                                    Debug.Log(counter);


                                    if (counter > lastTime)
                                    {
                                        finishStageTwo = true;

                                        //鼠标图标在这变一下+换眼睛

                                        eye1.SetActive(false);
                                        eye2.SetActive(true);

                                        //其他该干的在这干

                                        //鼠标变回来
                                    }


                                }
                            }
                        }
                    }
                }
                else
                {
                    if (Input.mouseScrollDelta.y > 0)
                    {
                        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
                        if (Physics.Raycast(r, out rh, Mathf.Infinity))
                        {
                            if (rh.collider.gameObject == button)

                            {
                                
                                if (!thirdlock)
                                {
                                   button. GetComponent<Animator>().Play("Switch");
                                    thirdlock = true;
                                    eye2.SetActive(false);
                                    eye3.SetActive(true);
                                }
                                //音效+相机拉起来
                            }
                        }
                    }
                }
            }
        }
       
    }


    bool thirdlock = false;
    bool finishStageTwo = false;

    bool finishStageOne = false;

    public float lastTime = 3f;
    float counter = 0;
    RaycastHit rh;
    Vector3 lastDisplacement = Vector3.zero;

    public GameObject body;
    public GameObject handle;
    public GameObject button;


    public GameObject eye1;
    public GameObject eye2;
    public GameObject eye3;
}


