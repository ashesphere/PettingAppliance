using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sound Fx")]
public class SoundFx : ScriptableObject
{
    public AudioClip clip;
    public float minGap = 0.16f;
    public float volume = 1f;

    public void Play()
    {
        SoundManager.current.PlayClip(this);
    }
}
