using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudioController : MonoBehaviour
{
    public AudioSource backgroundAudioSource;

    public void PauseBGAudio()
    {
        backgroundAudioSource.Pause();
    }

    public void ResumeBGAudio()
    {
        backgroundAudioSource.Play();
    }
}
