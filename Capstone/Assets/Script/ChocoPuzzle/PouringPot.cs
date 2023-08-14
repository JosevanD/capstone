using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;
//using UnityEngine.UI;

public class PouringPot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Animator potAnimator;
    public Animator moldAnimator;

    public ChocoPuzzleManager chocoPuzzleManager;
    public GameObject theNextPanel;
    public GameObject theCurrPanel;
   // public GameObject MixingMatchMilkPanel;
   //public GameObject StirringChocolatePanel;

    public float playerHoldingTimer;
    public float RequiredTimer;

    public bool isPouringFinished;
    private bool isPressingOn;
    private void Start()
    {
        playerHoldingTimer = 0;
        isPouringFinished = false;
        isPressingOn = false;
        chocoPuzzleManager = FindObjectOfType<ChocoPuzzleManager>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        
        if (playerHoldingTimer <= RequiredTimer) 
        {
            isPressingOn = true;
            potAnimator.SetBool("isPouringMilk", true);
            //potAnimator.speed = 1;
            moldAnimator.SetBool("isFilling", true);
            moldAnimator.speed = 1;
            playerHoldingTimer += Time.deltaTime;



        }

    }

    public void OnPointerUp(PointerEventData eventData) 
    {
        potAnimator.SetBool("isPouringMilk", false);
        isPressingOn = false;
        moldAnimator.speed = 0;
    }

    private void Update()
    {
        //Debug.Log("isPressingon " + isPressingOn);
        if (isPressingOn)
        {
            playerHoldingTimer += Time.deltaTime;

        }
        if (!isPressingOn)
        {
            potAnimator.SetBool("isPouringMilk", false);

        }
        if (playerHoldingTimer >= RequiredTimer)
        {

            //chocoPuzzleManager.IsPanelFinished = true;
            /*chocoPuzzleManager.ChocoPuzzleCanvas.enabled = false;
            chocoPuzzleManager.charactorController.isInteracting = false;
            theNextPanel.SetActive(true);
            theCurrPanel.SetActive(false);*/

            Debug.Log("Mixing Matcha Finished");
            chocoPuzzleManager.ChocoPuzzleCanvas.enabled = false;
            chocoPuzzleManager.charactorController.isInteracting = false;
            //theNextPanel.SetActive(true);
            chocoPuzzleManager.currPanels = ChocoPuzzleManager.CurrPanels.Oven;
            theCurrPanel.SetActive(false);



        }
    }
}
