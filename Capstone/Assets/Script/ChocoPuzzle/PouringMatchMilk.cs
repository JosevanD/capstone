using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class PouringMatchMilk : MonoBehaviour
{

    public Animator MatchaMilkBowlAnimator;
    public Animator WhiteChocoBowlAnimator;

    private ChocoPuzzleManager chocoPuzzleManager;
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

    public GameObject FilledWhiteChocoBowl;

    [Header("Instruction")]
    public TMP_Text TextObj;
    public string Instruction_1;
    public string Instruction_2;


    private void Start()
    {
        //isPouringFinished = false;
        isPressingOn = false;
        chocoPuzzleManager = FindObjectOfType<ChocoPuzzleManager>();
        StirringChocolatePanel.SetActive(false);
        chocoPuzzleManager.SwitchInstruction(TextObj, Instruction_1);
    }
    public void OnPointerDown()
    {

        MatchaMilkBowlAnimator.SetBool("isPouring", true);
        Invoke("nextPanel", 3);
        
    }


    public void DragObject()
    {
        objectToDrag.transform.position = Input.mousePosition;



    }


    void nextPanel() 
    {
        MatchaMilkBowlAnimator.SetBool("isPouring", false);
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
                MatchaMilkBowlAnimator.SetBool("isPouring", true);
                
                FillingTimer += Time.deltaTime;
                

            }
            //not in the range 
            if (Distance > DetectionDistance)
            {
                MatchaMilkBowlAnimator.SetBool("isPouring", false);
                

            }
            //finished
            if (FillingTimer >= MaxFillingTimer)
            {
                MatchaMilkBowlAnimator.SetBool("isPouring", false);
                
                isFinished = true;
                WhiteChocoObj.GetComponent<Image>().enabled = false;
                MatchaMilkBowlAnimator.GetComponent<Image>().enabled = false;
                FilledWhiteChocoBowl.SetActive(true);
                chocoPuzzleManager.SwitchInstruction(TextObj, Instruction_2);
                Invoke("nextPanel", 1);
                //Debug.Log("111");

            }

        }
    }
}


