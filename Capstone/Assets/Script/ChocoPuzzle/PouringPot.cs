using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
//using UnityEngine.UI;

public class PouringPot : MonoBehaviour
{
    public Animator MatchaBowlAnimator;
    public Animator MilkBowlAnimator;
    

    private ChocoPuzzleManager chocoPuzzleManager;
   
    public GameObject theCurrPanel;


    //public float playerHoldingTimer;
    //public float RequiredTimer;

    public bool isPouringFinished;

    [Header("Drag N Drop")]
    public GameObject objectToDrag;
    public GameObject objectDragToPos;
    //public float DropDistance;


    public bool isLocked = false;


    Vector2 objectInitPos;

    [Header("Pouring Milk SFX")]
    public AudioSource PouringMilkAudioSource;
    public AudioClip PouringMilkClip;



    public float MaxFillingTimer;
    public float FillingTimer;
    public float DetectionDistance;

    public GameObject MilkBowl;
    public GameObject MatchaBowl;

    public GameObject EmptyMilkBowl;
    public GameObject FilledMatchaBowl;
    private bool isFinished;

    [Header("Instruction")]
    public TMP_Text TextObj;
    public string Instruction_1;
    public string Instruction_2;

    private void Start()
    {
        //playerHoldingTimer = 0;
        isPouringFinished = false;
        chocoPuzzleManager = FindObjectOfType<ChocoPuzzleManager>();
        PouringMilkAudioSource = GetComponent<AudioSource>();
        objectInitPos = objectToDrag.transform.position;
        chocoPuzzleManager.SwitchInstruction(TextObj, Instruction_1);
        chocoPuzzleManager.cursorManager.ChangeToPalm();
    }



    private void Update()
    {
        if (isFinished == false)
        {
            float Distance = Vector3.Distance(MilkBowl.transform.position, MatchaBowl.transform.position);
            if (Distance <= DetectionDistance && !isFinished)
            {
                if (!PouringMilkAudioSource.isPlaying)
                {
                    PouringMilkAudioSource.PlayOneShot(PouringMilkClip);
                }
                MilkBowlAnimator.SetBool("isPouring", true);
                
                FillingTimer += Time.deltaTime;
                

            }
            //not in the range 
            if (Distance > DetectionDistance)
            {
                MilkBowlAnimator.SetBool("isPouring", false);
                //MatchaBowlAnimator.SetBool("isFillingMilk", false);
                PouringMilkAudioSource.Stop();

            }
            //finished
            if (FillingTimer >= MaxFillingTimer)
            {
                chocoPuzzleManager.cursorManager.SetCursorDefault();
                chocoPuzzleManager.EndingAudioSource.Stop();
                chocoPuzzleManager.EndingAudioSource.PlayOneShot(chocoPuzzleManager.EndingClip);
                MilkBowlAnimator.SetBool("isPouring", false);
                //MatchaBowlAnimator.SetBool("isFillingMilk", false);
                isFinished = true;
                MatchaBowl.GetComponent<Image>().enabled = false;
                MilkBowl.GetComponent<Image>().enabled = false;
                FilledMatchaBowl.SetActive(true);
                EmptyMilkBowl.SetActive(true);
                StartCoroutine(Countdown(chocoPuzzleManager.MaxEndingTime));
                //Debug.Log("111");

            }

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
        chocoPuzzleManager.currPanels = ChocoPuzzleManager.CurrPanels.Oven;
        theCurrPanel.SetActive(false);


    }


    public void DragObject()
    {
        if (!isLocked && !isFinished)
        {
            chocoPuzzleManager.cursorManager.ChangeToGrab();
            objectToDrag.transform.position = Input.mousePosition;

        }


    }

    public void OnMouseUp()
    {
        chocoPuzzleManager.cursorManager.ChangeToPalm();


    }

}
