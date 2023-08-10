using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouringMatchMilk : MonoBehaviour
{
    
    public Animator potAnimator;
    public Animator moldAnimator;

    public ChocoPuzzleManager chocoPuzzleManager;
    public GameObject StirringChocolatePanel;
    //public GameObject 

    private float playerHoldingTimer;
    public float RequiredTimer;

    
    //public bool isPouringFinished;
    private void Start()
    {
        //isPouringFinished = false;
        chocoPuzzleManager = FindObjectOfType<ChocoPuzzleManager>();
        StirringChocolatePanel.SetActive(false);
    }
    public void OnPointerDown()
    {
        if (playerHoldingTimer < RequiredTimer)
        {
            potAnimator.SetBool("isPouring", true);
            //potAnimator.speed = 1;
            moldAnimator.SetBool("isFilling", true);
            moldAnimator.speed = 1;
            playerHoldingTimer += Time.deltaTime;

        }

    }

    public void OnPointerUp()
    {
        potAnimator.SetBool("isPouring", false);

        moldAnimator.speed = 0;
    }

    private void Update()
    {
        if (playerHoldingTimer < RequiredTimer)
        {
            //isPouringFinished = true;
            StirringChocolatePanel.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}


