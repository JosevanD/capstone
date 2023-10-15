using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StirringChoco : MonoBehaviour
{
    private ChocoPuzzleManager chocoPuzzleManager;

    private PouringMatchMilk pouringMatchMilk;
    public GameObject objectToDrag;
    //public GameObject theNextPanel;
    public GameObject theCurrPanel;
    public Animator MatchaChocoAnimator;


    private bool isPressingOn;

    private float startTime = 0f;
    private float pressTime = 0f;

    public float totalPressTime = 0f;

    private bool isFinished = false;

    [Header("Stirring SFX")]
    public AudioSource StirringAudioSource;
    public AudioClip StirringClip;

    private void Start()
    {
        isFinished = false;
        pouringMatchMilk = FindObjectOfType<PouringMatchMilk>();
        chocoPuzzleManager = FindObjectOfType<ChocoPuzzleManager>();
        StirringAudioSource = GetComponent<AudioSource>();
        StirringAudioSource.clip = StirringClip;
        StirringAudioSource.enabled = false;
        isPressingOn = false;
    }
    public void OnMouseDrag()
    {
        if (isFinished == false) 
        {
            isPressingOn = true;
            objectToDrag.transform.position = Input.mousePosition;
            //MatchaChocoAnimator.SetBool("isFilling", false);
            MatchaChocoAnimator.SetBool("isStirring", true);
            StirringAudioSource.enabled = true;
            MatchaChocoAnimator.speed = 1;
            pressTime += Time.deltaTime;
        }
        


    }
    public void OnMouseUp()
    {
        //pressTime = Time.time - pressTime;
        MatchaChocoAnimator.SetBool("isStirring", false);
        //Debug.Log("press Time is " + pressTime);
        MatchaChocoAnimator.speed = 0;
        StirringAudioSource.enabled = false;
        pressTime = 0;
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
        chocoPuzzleManager.currPanels = ChocoPuzzleManager.CurrPanels.FillingTart;
        theCurrPanel.SetActive(false);


    }

    void Update()
    {
        //Debug.Log("1");

        if (pressTime >= totalPressTime)
        {
            chocoPuzzleManager.EndingAudioSource.Stop();
            chocoPuzzleManager.EndingAudioSource.PlayOneShot(chocoPuzzleManager.EndingClip);
            MatchaChocoAnimator.SetBool("isStirring", false);
            isFinished = true;
            gameObject.GetComponent<Image>().enabled = false;
            StartCoroutine(Countdown(3));
            
        }
    }
}
