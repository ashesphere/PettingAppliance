using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FDoorUp : MonoBehaviour
{
    void Start()
    {

Physics.queriesHitTriggers=true;
    }

    void Update()
    {

    }

    public void Init()
    {
PlayCloseAni();
    }

    public void Init2(){
        
        PlayOpenAni();
    }

    bool isOpen = false;
 public    void ChangeAnimation()
    {
        if (!isOpen)
        {

            PlayOpenAni();
        }
        else
        {

            PlayCloseAni();
                    if(FMilk.GetEventNum()==2/*&&FCat.GetCatHappy()*/){

                    //game end
                    gameend.SetActive(true);
                }
        }
        isOpen = !isOpen;
    }
public Animator animator;
    void PlayOpenAni()
    {


animator.Play("Open");
    }

    void PlayCloseAni()
    {

        animator.Play("Close");
    }

    public GameObject gameend;
}
