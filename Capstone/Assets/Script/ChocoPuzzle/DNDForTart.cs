using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNDForTart : MonoBehaviour
{
    private ChocoPuzzleManager chocoPuzzleManager;
    public GameObject objectToDrag;
    public GameObject theNextPanel;
    public GameObject theCurrPanel;
    private int TotalTartCount;
    public int TartCount;
    Vector2 objectInitPos;

    //private float pressTime = 0f;
    //public float totalPressTime = 0f;
    private void Start()
    {
        TotalTartCount = GameObject.FindGameObjectsWithTag("Tart").Length;

        chocoPuzzleManager = FindObjectOfType<ChocoPuzzleManager>();

        objectInitPos = objectToDrag.transform.position;
    }

    /*public void OnMouseDrag()
    {

        objectToDrag.transform.position = Input.mousePosition;
        pressTime += Time.deltaTime;


    }*/
    public void OnMouseDrag()
    {
        objectToDrag.transform.position = Input.mousePosition;
        //pressTime += Time.deltaTime;
    }

    private void Update()
    {
        if (TartCount >= TotalTartCount)
        {
            /*chocoPuzzleManager.ChocoPuzzleCanvas.enabled = false;
            chocoPuzzleManager.charactorController.isInteracting = false;
            theNextPanel.SetActive(true);
            theCurrPenel.SetActive(false);*/
            chocoPuzzleManager.ChocoPuzzleCanvas.enabled = false;
            chocoPuzzleManager.charactorController.isInteracting = false;
            //theNextPanel.SetActive(true);
            chocoPuzzleManager.currPanels = ChocoPuzzleManager.CurrPanels.PlacingChoco;
            theCurrPanel.SetActive(false);

        }
    }


    /*public void OnMouseUp()
    {
        objectToDrag.transform.position = objectInitPos;
    }*/


}
