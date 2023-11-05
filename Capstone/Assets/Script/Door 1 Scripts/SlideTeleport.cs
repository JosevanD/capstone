using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideTeleport : MonoBehaviour
{
    [Header("Slide SFX")]
    private AudioSource SlideAudioSource;
    public AudioClip SlideDownClip;

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
}
