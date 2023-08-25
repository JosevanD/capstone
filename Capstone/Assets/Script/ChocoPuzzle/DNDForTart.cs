using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNDForTart : MonoBehaviour
{
    private ChocoPuzzleManager chocoPuzzleManager;


    public GameObject objectToDrag;
    public float DetectionRadius;
    
    public GameObject theCurrPanel;
    public int TotalTartCount;
    public GameObject[] Tarts; 
    public int TartCount;
    public LayerMask UI;
    Vector2 objectInitPos;

    //private float pressTime = 0f;
    //public float totalPressTime = 0f;
    private void Start()
    {
        TotalTartCount = GameObject.FindGameObjectsWithTag("Tart").Length;
        Tarts = GameObject.FindGameObjectsWithTag("Tart");
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
        chocoPuzzleManager.currPanels = ChocoPuzzleManager.CurrPanels.Packing;
        theCurrPanel.SetActive(false);


    }

    private void Update()
    {

        Tarts[TartCount].GetComponent<ChangingTartSprite>().enabled = true;
        if (TartCount >= TotalTartCount)
        {
            StartCoroutine(Countdown(chocoPuzzleManager.MaxEndingTime));

        }
    }


    /*public void OnMouseUp()
    {
        objectToDrag.transform.position = objectInitPos;
    }*/


}
