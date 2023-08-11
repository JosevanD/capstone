using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StirringChoco : MonoBehaviour
{
    public ChocoPuzzleManager chocoPuzzleManager;
    public GameObject objectToDrag;
    public GameObject theNextPanel;
    public GameObject theCurrPenel;

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
        pressTime += Time.deltaTime;


    }
    public void OnMouseUp()
    {
        //pressTime = Time.time - pressTime;
       
        Debug.Log("press Time is " + pressTime);
        pressTime = 0;
    }

    void Update()
    {
        //Debug.Log("1");

        if (pressTime >= totalPressTime)
        {
            chocoPuzzleManager.ChocoPuzzleCanvas.enabled = false;
            chocoPuzzleManager.charactorController.isInteracting = true;
            theNextPanel.SetActive(true);
            theCurrPenel.SetActive(false);
            Debug.Log("Stirring Choco is finished");
        }
    }
}
