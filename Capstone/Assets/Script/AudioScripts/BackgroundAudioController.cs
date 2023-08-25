using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BackgroundAudioController : MonoBehaviour
{
    private static BackgroundAudioController backgroundAudioController;

    public AudioSource backgroundAudioSource;

    [SerializeField] float fadeDuration;
    [SerializeField] AudioClip[] bgAudioClips;
    
    public float audioVolume;
    [Header("Volume Slider")]
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private bool isVolumeSliderActive;
    private bool isVolumeSliderFound;

    private void Awake()
    {
        //ensuring script object is not destroyed through changing scenes
        DontDestroyOnLoad(transform.gameObject);

        //ensuring no duplicates
        if (backgroundAudioController == null)
        {
            backgroundAudioController = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Update()
    {
        

        if (isVolumeSliderActive == true)
        {
            if (isVolumeSliderFound == false)
            {
                FindVolumeSlider();
            }

            audioVolume = volumeSlider.value;
        }

        else
        {
            isVolumeSliderFound = false;
        }
    }
    public void PauseBGAudio()
    {
        backgroundAudioSource.DOFade(0, fadeDuration);
        //backgroundAudioSource.Pause();
    }

    public void ResumeBGAudio()
    {
        //backgroundAudioSource.Play();
        backgroundAudioSource.DOFade(audioVolume, fadeDuration);
    }

    public void ChangeAudio(int clipNo)
    {

        //backgroundAudioSource.clip = bgAudioClips[clipNo];
        
        StartCoroutine((FadeNewClip(fadeDuration, clipNo)));
    }

    IEnumerator FadeNewClip(float time, int clipNo)
    {
        backgroundAudioSource.DOFade(0, fadeDuration);

        yield return new WaitForSeconds(time);

        backgroundAudioSource.clip = bgAudioClips[clipNo];
        backgroundAudioSource.Play();
        backgroundAudioSource.DOFade(audioVolume, fadeDuration);
    }

    public void VolumeSliderActive()
    {
        isVolumeSliderActive = true;
    }
    public void VolumeSliderInActive()
    {
        isVolumeSliderActive = false;
    }
    private void FindVolumeSlider()
    {
        volumeSlider = GameObject.FindGameObjectWithTag("Volume Slider").GetComponent<Slider>();
        isVolumeSliderFound = true;
    }
}
