using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine;

public class FDrawerUp : MonoBehaviour
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

    bool isOpen = false;
    public bool GetIsOpen()
    {
        return isOpen;
    }

    public void ChangeAnimation()
    {
        if (!isOpen)
        {

            if (FDoorDown.isOpen)
            {
                PlayOpenAni(); isOpen = !isOpen;
            }
        }
        else
        {

            if (FDoorDown.isOpen)
            {
                PlayCloseAni(); isOpen = !isOpen;

 
            }
        }

    }
    public Animator animator;
    public void PlayOpenAni()
    {


        animator.Play("Open");
    }

    public void PlayCloseAni()
    {

        animator.Play("Close");
    }
}
