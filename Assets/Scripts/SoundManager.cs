using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingleTon<SoundManager>
{
    class ClipRequest {
        public float time;
        public bool isPlayed;
    }

    [SerializeField]new AudioSource audio;

    int fadeState;

    Dictionary<SoundFx, ClipRequest> clipTimeDic = new Dictionary<SoundFx,ClipRequest>();

    void Start(){
        if (!audio) audio = FindObjectOfType<AudioSource>();
    }

    void LateUpdate() {
        foreach(SoundFx clip in clipTimeDic.Keys) {
            var request = clipTimeDic[clip];
            bool isPlayed = (bool) request.isPlayed;
            if (!isPlayed) {
                audio.PlayOneShot(clip.clip, clip.volume);
                request.isPlayed = true;
                request.time = Time.time;
            }
        }
        audio.volume += Time.deltaTime * fadeState;
        if (audio.volume <= 0f && fadeState == -1)
            fadeState = 0;
    }

    public void PlayClip(SoundFx clip){
        if (clip == null) return;
        if (clipTimeDic.ContainsKey(clip) == false) 
            clipTimeDic.Add(clip, 
                new ClipRequest{time = Time.time, isPlayed = false});
        else {
            var request = clipTimeDic[clip];
            float previousPlayedTime = request.time;
            bool isPlayed = request.isPlayed;
            if (previousPlayedTime + clip.minGap < Time.time) {
                request.time = Time.time;
                request.isPlayed = false;
            }
        }
    }

    public void FadeOut()
    {
        fadeState = -1;
    }
}
