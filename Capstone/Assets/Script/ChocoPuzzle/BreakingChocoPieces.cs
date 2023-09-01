using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
}
