using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StirringChoco : MonoBehaviour
{
    public ChocoPuzzleManager chocoPuzzleManager;
    public GameObject objectToDrag;
    //public GameObject theNextPanel;
    public GameObject theCurrPanel;
    public Animator MatchaChocoAnimator;

    private float startTime = 0f;
    private float pressTime = 0f;

    public float totalPressTime = 0f;

    private void Start()
    {
        chocoPuzzleManager = FindObjectOfType<ChocoPuzzleManager>();
    }
    public void OnMouseDrag()
    {
        
        objectToDrag.transform.position = Input.mousePosition;
        MatchaChocoAnimator.SetBool("isStirring", true);
        MatchaChocoAnimator.speed = 1;
        pressTime += Time.deltaTime;


    }
    public void OnMouseUp()
    {
        //pressTime = Time.time - pressTime;
       
        Debug.Log("press Time is " + pressTime);
        MatchaChocoAnimator.speed = 0;
        pressTime = 0;
    }

    void Update()
    {
        //Debug.Log("1");

        if (pressTime >= totalPressTime)
        {
            /*chocoPuzzleManager.ChocoPuzzleCanvas.enabled = false;
            chocoPuzzleManager.charactorController.isInteracting = true;
            theNextPanel.SetActive(true);
            theCurrPanel.SetActive(false);*/

            chocoPuzzleManager.ChocoPuzzleCanvas.enabled = false;
            chocoPuzzleManager.charactorController.isInteracting = false;
            //theNextPanel.SetActive(true);
            chocoPuzzleManager.currPanels = ChocoPuzzleManager.CurrPanels.FillingTart;
            theCurrPanel.SetActive(false);
            Debug.Log("Stirring Choco is finished");
        }
    }
}
