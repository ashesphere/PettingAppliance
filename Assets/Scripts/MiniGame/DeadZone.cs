using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public AudioClip AO;
    public AudioSource source;
    void OnTriggerEnter(Collider other)
    {
        var miniCat = other.GetComponent<MiniCat>();
        if (miniCat)
        {
            source.PlayOneShot(AO,1F);
            MiniGame.MiniGameCatChaseMouse.current.Restart();
        }
    }
}
