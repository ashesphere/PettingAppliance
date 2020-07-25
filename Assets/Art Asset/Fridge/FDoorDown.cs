using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FDoorDown : MonoBehaviour
{
    void Start()
    {


    }

    void Update()
    {

    }

    public void Init()
    {
        PlayCloseAni();
    }

    public void Init2()
    {

        PlayOpenAni();
    }

    public static bool isOpen = false;

    public void ChangeAnimation()
    {
        if (!isOpen)
        {


            PlayOpenAni();
            isOpen = !isOpen;
        }
        else
        {
            if (drawer1.GetIsOpen() || drawer2.GetIsOpen())
            {

                //???

            }
            else
            {
                PlayCloseAni(); isOpen = !isOpen;
                if (FMilk.GetEventNum() == 2/* && FCat.GetCatHappy()*/)
                {

                    //game end
                    gameend.SetActive(true);
                }
            }
        }

    }
    public Animator animator;

    public FDrawerUp drawer1;
    public FDrawerUp drawer2;
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
