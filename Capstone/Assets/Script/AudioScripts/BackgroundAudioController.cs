using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
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

    [SerializeField] AudioMixer mixer;

    public const string MASTER_KEY = "masterVolume";
    public const string MUSIC_KEY = "musicVolume";
    public const string SFX_KEY = "sfxVolume";

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

        LoadVolume();
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

    void LoadVolume()
    {
        float masterVolume = PlayerPrefs.GetFloat(MASTER_KEY, 1f);
        float musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, 1f);
        float sfxVolume = PlayerPrefs.GetFloat(SFX_KEY, 1f);

        mixer.SetFloat(VolumeController.MIXER_MASTER, Mathf.Log10(masterVolume * 20));
        mixer.SetFloat(VolumeController.MIXER_MUSIC, Mathf.Log10(musicVolume *20));
        mixer.SetFloat(VolumeController.MIXER_SFX, Mathf.Log10(sfxVolume *20));
        
    }

}
