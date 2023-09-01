using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;
//using UnityEngine.UI;

public class PouringPot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Animator potAnimator;
    public Animator bowlAnimator;
    public AnimationClip bowlAnimationClip;

    public ChocoPuzzleManager chocoPuzzleManager;
    //public GameObject theNextPanel;
    public GameObject theCurrPanel;
   // public GameObject MixingMatchMilkPanel;
   //public GameObject StirringChocolatePanel;

    public float playerHoldingTimer;
    public float RequiredTimer;

    public bool isPouringFinished;
    private bool isPressingOn;

    [Header("Pouring Milk SFX")]
    public AudioSource PouringMilkAudioSource;
    public AudioClip PouringMilkClip;

    private void Start()
    {
        playerHoldingTimer = 0;
        isPouringFinished = false;
        isPressingOn = false;
        chocoPuzzleManager = FindObjectOfType<ChocoPuzzleManager>();
        PouringMilkAudioSource = GetComponent<AudioSource>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {

        /*if (playerHoldingTimer <= RequiredTimer) 
        {
            isPressingOn = true;
            potAnimator.SetBool("isPouringMilk", true);
            //potAnimator.speed = 1;
            bowlAnimator.SetBool("isFillingMilk", true);
            bowlAnimator.speed = 1;
            playerHoldingTimer += Time.deltaTime;



        }*/
        potAnimator.SetBool("isPouringMilk", true);
        bowlAnimator.SetBool("isFillingMilk", true);
        PouringMilkAudioSource.PlayOneShot(PouringMilkClip);
        StartCoroutine(Countdown( 4 + chocoPuzzleManager.MaxEndingTime));
        //PlayAndWaitForAnim(bowlAnimator, "FillingMilk");

    }

    public void OnPointerUp(PointerEventData eventData) 
    {
        potAnimator.SetBool("isPouringMilk", false);
        isPressingOn = false;
        bowlAnimator.speed = 0;
    }

    private void Update()
    {
        //Debug.Log("isPressingon " + isPressingOn);
        /*if (isPressingOn)
        {
            playerHoldingTimer += Time.deltaTime;

        }
        if (!isPressingOn)
        {
            potAnimator.SetBool("isPouringMilk", false);

        }
        if (playerHoldingTimer >= RequiredTimer)
        {


            StartCoroutine(Countdown(chocoPuzzleManager.MaxEndingTime));



        }
        */

        //Debug.Log(Mathf.CeilToInt(bowlAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime * bowlAnimationClip.length));
        if (bowlAnimator.GetCurrentAnimatorStateInfo(0).IsName("FillingMilk"))
        {
            Debug.Log("It's finished");
           

        }
        


    }

    public IEnumerator PlayAndWaitForAnim(Animator targetAnim, string stateName)
    {
        targetAnim.Play(stateName);

        //Wait until we enter the current state
        while (!targetAnim.GetCurrentAnimatorStateInfo(0).IsName(stateName))
        {
            yield return null;
        }

        //Now, Wait until the current state is done playing
        while ((targetAnim.GetCurrentAnimatorStateInfo(0).normalizedTime) % 1 < 0.99f)
        {
            yield return null;
        }

        //Done playing. Do something below!
        Debug.Log("Animation is finished");
        StartCoroutine(Countdown(chocoPuzzleManager.MaxEndingTime));
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
        chocoPuzzleManager.currPanels = ChocoPuzzleManager.CurrPanels.Oven;
        theCurrPanel.SetActive(false);


    }
}
