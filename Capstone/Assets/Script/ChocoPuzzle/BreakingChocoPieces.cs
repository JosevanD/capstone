using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class BreakingChocoPieces : MonoBehaviour
{
    public int totalChocolateCount;

    public int brokenChocolateCount;

    //public Image CurrentChocolateImage;

    public Sprite BrokenChocolateSprite;

    private ChocoPuzzleManager chocoPuzzleManager;

    public GameObject theCurrPanel;
    public Canvas ChocolatePuzzleCanvas;
    [Header("BreakingChoco SFX")]
    public AudioSource BreakingChocoAudioSource;
    public AudioClip BreakingChocoClip;

    [Header("Screen Shake")]
    public CinemachineVirtualCamera CinemachineVirtualCamera;
    private float screenShakerTimer;
    private float shakeTimerTotal;
    private float startingIntensity; 
    // Start is called before the first frame update
    void Start()
    {
        chocoPuzzleManager = FindObjectOfType<ChocoPuzzleManager>();
        BreakingChocoAudioSource = GetComponent<AudioSource>();
        totalChocolateCount = GameObject.FindGameObjectsWithTag("Choco Pieces").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (brokenChocolateCount >= totalChocolateCount)
        {
            StartCoroutine(Countdown(chocoPuzzleManager.MaxEndingTime));

        }

        if (screenShakerTimer > 0)
        {

            screenShakerTimer -= Time.deltaTime;
            if (screenShakerTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
                    //Mathf.Lerp(startingIntensity, 0f, screenShakerTimer / shakeTimerTotal);
                
                
            }
        }
    }

    public void SwitchChocoSprite(GameObject gameObjectSelf)
    {
        BreakingChocoAudioSource.Stop();
        BreakingChocoAudioSource.PlayOneShot(BreakingChocoClip);
        gameObjectSelf.GetComponent<Image>().sprite = BrokenChocolateSprite;
        
    }

    IEnumerator Countdown(int seconds)
    {
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }

        chocoPuzzleManager.ChocoPuzzleCanvas.enabled = false;
        chocoPuzzleManager.charactorController.isInteracting = false;
        chocoPuzzleManager.currPanels = ChocoPuzzleManager.CurrPanels.MixingMatcha;
        theCurrPanel.SetActive(false);


    }

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        screenShakerTimer = time;
        shakeTimerTotal = time;
        startingIntensity = intensity;

    }

}
