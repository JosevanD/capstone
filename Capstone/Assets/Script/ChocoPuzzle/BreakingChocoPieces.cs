using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using TMPro;

public class BreakingChocoPieces : MonoBehaviour
{
    public int totalChocolateCount;

    public int brokenChocolateCount;

    //public Image CurrentChocolateImage;
   
    

    private ChocoPuzzleManager chocoPuzzleManager;

    public GameObject theCurrPanel;
    public Canvas ChocolatePuzzleCanvas;

    public GameObject BrokenChocoPiecesAll;

    [Header("BreakingChoco SFX")]
    public AudioSource BreakingChocoAudioSource;
    public AudioClip BreakingChocoClip;

    [Header("Screen Shake")]
    public CinemachineVirtualCamera CinemachineVirtualCamera;
    private float screenShakerTimer;
    private float shakeTimerTotal;
    private float startingIntensity;

    [Header("Instruction")]
    public TMP_Text TextObj;
    public string Instruction_1;
    public string Instruction_2;


    // Start is called before the first frame update
    void Start()
    {
        BrokenChocoPiecesAll.SetActive(false);
        chocoPuzzleManager = FindObjectOfType<ChocoPuzzleManager>();
        BreakingChocoAudioSource = GetComponent<AudioSource>();
        totalChocolateCount = GameObject.FindGameObjectsWithTag("Choco Pieces").Length;
        chocoPuzzleManager.SwitchInstruction(TextObj, Instruction_1);
    }

    // Update is called once per frame
    void Update()
    {
        if (brokenChocolateCount >= totalChocolateCount)
        {
            GameObject[] BrokenPices = GameObject.FindGameObjectsWithTag("Choco Pieces");
            foreach (GameObject BrokenPice in BrokenPices)
            {
                BrokenPice.SetActive(false);
            }
            chocoPuzzleManager.SwitchInstruction(TextObj, Instruction_2);
            BrokenChocoPiecesAll.SetActive(true);


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

    public void SwitchChocoSprite()
    {
        BreakingChocoAudioSource.Stop();
        BreakingChocoAudioSource.PlayOneShot(BreakingChocoClip);
       
        
    }

    public IEnumerator Countdown(int seconds)
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
