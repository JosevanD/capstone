using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchImage : MonoBehaviour
{
    public GameObject[] ChocolateImages;

    public ChocoPuzzleManager chocoPuzzleManager;

    public GameObject theNextPanel;
    public GameObject theCurrPanel;
    public Canvas ChocolatePuzzleCanvas;
    private int ImageCount = 0;
    [Header("BreakingChoco SFX")]
    public AudioSource BreakingChocoAudioSource;
    public AudioClip BreakingChocoClip;

    private void Start()
    {
        chocoPuzzleManager = FindObjectOfType<ChocoPuzzleManager>();
        BreakingChocoAudioSource = GetComponent<AudioSource>();
        //BreakingChocoAudioSource.clip = BreakingChocoClip;
        Debug.Log(ChocolateImages.Length);
    }

    public void OnPointerDown()
    {
        if (ImageCount < ChocolateImages.Length - 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                BreakingChocoAudioSource.Stop();
                BreakingChocoAudioSource.PlayOneShot(BreakingChocoClip);
                ImageCount++;
                ChocolateImages[ImageCount].SetActive(true);

                Debug.Log("Current Image No is " + ImageCount);

                ChocolateImages[ImageCount - 1].SetActive(false);

                Debug.Log("last Image No is " + ImageCount);




            }


        }
        if (ImageCount >= ChocolateImages.Length - 1)
        {
            Debug.Log("Breaking Choco is finished");

            //ChocolatePuzzleCanvas.enabled = false;
            StartCoroutine(Countdown(chocoPuzzleManager.MaxEndingTime));

        }

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

}
