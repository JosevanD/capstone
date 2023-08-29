using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider masterSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    public const string MIXER_MASTER = "MasterVolume";
    public const string MIXER_MUSIC = "MusicVolume";
    public const string MIXER_SFX = "SFXVolume";

    private void Awake()
    {
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    private void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat(BackgroundAudioController.MASTER_KEY, 1f);
        musicSlider.value = PlayerPrefs.GetFloat(BackgroundAudioController.MUSIC_KEY, 1f);
        sfxSlider.value = PlayerPrefs.GetFloat(BackgroundAudioController.SFX_KEY, 1f);

    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat(BackgroundAudioController.MASTER_KEY, masterSlider.value);
        PlayerPrefs.SetFloat(BackgroundAudioController.MUSIC_KEY, musicSlider.value);
        PlayerPrefs.SetFloat(BackgroundAudioController.MUSIC_KEY, sfxSlider.value);
    }
    void SetMasterVolume(float value)
    {
        mixer.SetFloat(MIXER_MASTER, Mathf.Log10(value) * 20);
    }
    void SetMusicVolume(float value)
    {
        mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
    }
    void SetSFXVolume(float value)
    {
        mixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
    }
}
