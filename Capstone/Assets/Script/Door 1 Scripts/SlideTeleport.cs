using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideTeleport : MonoBehaviour
{
    [Header("Slide SFX")]
    private AudioSource SlideAudioSource;
    public AudioClip SlideDownClip;
    public AudioClip SlideStepClip1;
    public AudioClip SlideStepClip2;
    public AudioClip SlideStepClip3;
    public AudioClip SlideStepClipWhole;



    [SerializeField] GameObject player;
    [SerializeField] GameObject teleportObj;

    private void Start()
    {

        SlideAudioSource = GetComponent<AudioSource>();
    }
    public void PlayerTeleportSlide()
    {
        player.transform.position = teleportObj.transform.position;
    }

    public void PlaySlideDownClip()
    {
        SlideAudioSource.PlayOneShot(SlideDownClip);

    }

    public void StopClip()
    {
        SlideAudioSource.Stop();
    }

    public void PlaySlideStepClip1()
    {
        StopClip();
        SlideAudioSource.PlayOneShot(SlideStepClip1);

    }
    public void PlaySlideStepClip2()
    {
        StopClip();
        SlideAudioSource.PlayOneShot(SlideStepClip2);

    }
    public void PlaySlideStepClip3()
    {
        StopClip();
        SlideAudioSource.PlayOneShot(SlideStepClip3);

    }
    public void PlaySlideStepClipWhole()
    {
        StopClip();
        SlideAudioSource.PlayOneShot(SlideStepClipWhole);

    }
}
