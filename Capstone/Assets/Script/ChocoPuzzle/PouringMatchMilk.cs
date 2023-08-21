using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PouringMatchMilk : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    
    public Animator potAnimator;
    public Animator moldAnimator;

    //public ChocoPuzzleManager chocoPuzzleManager;
    public GameObject StirringChocolatePanel;
    //public GameObject 

    private float playerHoldingTimer;
    public float RequiredTimer;

    private bool isPressingOn;
    //public bool isPouringFinished;
    private void Start()
    {
        //isPouringFinished = false;
        isPressingOn = false;
        //chocoPuzzleManager = FindObjectOfType<ChocoPuzzleManager>();
        StirringChocolatePanel.SetActive(false);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (playerHoldingTimer <= RequiredTimer)
        {
            isPressingOn = true;
            potAnimator.SetBool("isPouring", true);
            //potAnimator.speed = 1;
            moldAnimator.SetBool("isFilling", true);
            moldAnimator.speed = 1;
            //playerHoldingTimer += Time.deltaTime;

        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        potAnimator.SetBool("isPouring", false);
        isPressingOn = false;
        moldAnimator.speed = 0;
    }

    private void Update()
    {
        //Debug.Log("isPressingon " + isPressingOn);
        if (isPressingOn)
        {
            playerHoldingTimer += Time.deltaTime;
            moldAnimator.SetBool("isFilling", true);

        }
        if (!isPressingOn)
        {
            //playerHoldingTimer += Time.deltaTime;
            moldAnimator.SetBool("isFilling", false);
            
        }
        if (playerHoldingTimer >= RequiredTimer)
        {
            //isPouringFinished = true;
            StirringChocolatePanel.SetActive(true);
            //moldAnimator.StopPlayback();
            //moldAnimator.speed = 0;
            //moldAnimator.SetBool("isStirring", false);
            gameObject.SetActive(false);
        }
    }
}


