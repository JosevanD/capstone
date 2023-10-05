using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PouringMatchMilk : MonoBehaviour
{

    public Animator MatchaMilkBowlAnimator;
    public Animator WhiteChocoBowlAnimator;

    //public ChocoPuzzleManager chocoPuzzleManager;
    public GameObject StirringChocolatePanel;
    //public GameObject 

    private float playerHoldingTimer;
    public float RequiredTimer;

    private bool isPressingOn;
    //public bool isPouringFinished;

    [Header("Drag N Drop")]
    public GameObject objectToDrag;
    public GameObject objectDragToPos;
    public bool isLocked = false;
    Vector2 objectInitPos;
    private bool isFinished;
    public float MaxFillingTimer;
    public float FillingTimer;
    public float DetectionDistance;


    [Header("MatchaMilk and White Choco")]
    public GameObject MatchaMilkObj;
    public GameObject WhiteChocoObj;

    //public GameObject EmptyMatchaMilkBowl;
    public GameObject FilledWhiteChocoBowl;

    private void Start()
    {
        //isPouringFinished = false;
        isPressingOn = false;
        //chocoPuzzleManager = FindObjectOfType<ChocoPuzzleManager>();
        StirringChocolatePanel.SetActive(false);
    }
    public void OnPointerDown()
    {
        /*if (playerHoldingTimer <= RequiredTimer)
        {
            isPressingOn = true;
            potAnimator.SetBool("isPouring", true);
            //potAnimator.speed = 1;
            moldAnimator.SetBool("isFilling", true);
            moldAnimator.speed = 1;
            //playerHoldingTimer += Time.deltaTime;

        }*/

        MatchaMilkBowlAnimator.SetBool("isPouring", true);
        //moldAnimator.SetBool("isFilling", true);
        Invoke("nextPanel", 3);
        
    }


    public void DragObject()
    {
        objectToDrag.transform.position = Input.mousePosition;



    }



    /*public void OnPointerUp(PointerEventData eventData)
    {
        potAnimator.SetBool("isPouring", false);
        isPressingOn = false;
        moldAnimator.speed = 0;
    }*/

    void nextPanel() 
    {
        MatchaMilkBowlAnimator.SetBool("isPouring", false);
        //moldAnimator.SetBool("isFilling", false);
        StirringChocolatePanel.SetActive(true);
        gameObject.SetActive(false);

    }

    private void Update()
    {
        if (isFinished == false)
        {
            float Distance = Vector3.Distance(MatchaMilkObj.transform.position, WhiteChocoObj.transform.position);
            if (Distance <= DetectionDistance && !isFinished)
            {
                /* if (!PouringMilkAudioSource.isPlaying)
                 {
                     PouringMilkAudioSource.PlayOneShot(PouringMilkClip);
                 }*/
                MatchaMilkBowlAnimator.SetBool("isPouring", true);
                //MatchaBowlAnimator.SetBool("isFillingMilk", true);
                FillingTimer += Time.deltaTime;
                //Debug.Log("collide" + gameObject);

            }
            //not in the range 
            if (Distance > DetectionDistance)
            {
                MatchaMilkBowlAnimator.SetBool("isPouring", false);
                //MatchaBowlAnimator.SetBool("isFillingMilk", false);
                //PouringMilkAudioSource.Stop();

            }
            //finished
            if (FillingTimer >= MaxFillingTimer)
            {
                MatchaMilkBowlAnimator.SetBool("isPouring", false);
                //MatchaBowlAnimator.SetBool("isFillingMilk", false);
                isFinished = true;
                WhiteChocoObj.GetComponent<Image>().enabled = false;
                MatchaMilkBowlAnimator.GetComponent<Image>().enabled = false;
                FilledWhiteChocoBowl.SetActive(true);
                //EmptyMatchaMilkBowl.SetActive(true);
                Invoke("nextPanel", 1);
                //Debug.Log("111");

            }

        }
    }
}


