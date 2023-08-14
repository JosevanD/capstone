using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChocoPuzzleManager : MonoBehaviour
{
    public enum CurrPanels
    {
       BreakingChoco,
       MixingMatcha,
       Oven,
       StirringChoco,
       FillingTart,
       PlacingChoco,
       Packing,
       AllFinished
    
    
    
    }


    public Canvas ChocoPuzzleCanvas;
    public Charactor_Controller charactorController;

    /*public GameObject BreakingChocoPanel;
    public GameObject MixingMatchaPanel;
    public GameObject OvenPanel;*/
    public GameObject[] ChocoPuzzleObjects;

    public int ChocoPuzzleObjectsNum;
    public bool IsPanelFinished;
    public int ChocolatesPlaced;
    public CurrPanels currPanels;

    private void Start()
    {
        ChocolatesPlaced = 0;
        ChocoPuzzleObjectsNum = 0;
        charactorController = FindObjectOfType<Charactor_Controller>();

        ChocoPuzzleObjects[ChocoPuzzleObjectsNum].SetActive(true);
        Debug.Log("Panel Number 0 is " + ChocoPuzzleObjectsNum);
        Debug.Log("ISPanelfinished " + IsPanelFinished);
        currPanels = CurrPanels.BreakingChoco;
        IsPanelFinished = false;
        
    }

    private void Update()
    {
        /*if (IsPanelFinished == true && ChocoPuzzleObjectsNum <= ChocoPuzzleObjects.Length - 1);
        {
            Debug.Log(IsPanelFinished);

            IsPanelFinished = false;
            Debug.Log("Panel Number 0 is " + ChocoPuzzleObjectsNum);
            ChocoPuzzleObjectsNum += 1;
            Debug.Log("Panel Number 1 is " + ChocoPuzzleObjectsNum);

            ChocoPuzzleObjects[ChocoPuzzleObjectsNum].SetActive(true);
            ChocoPuzzleObjects[ChocoPuzzleObjectsNum - 1].SetActive(false);
           

        }*/
        /*if (IsPanelFinished == true)
        {
            charactorController.isInteracting = false;
        
        }*/
        switch (currPanels)
        {
            case CurrPanels.BreakingChoco:
                ChocoPuzzleObjects[0].SetActive(true);
                break;
            case CurrPanels.MixingMatcha:
                Destroy(ChocoPuzzleObjects[0]);
                ChocoPuzzleObjects[1].SetActive(true);
                break;
            case CurrPanels.Oven:
                Destroy(ChocoPuzzleObjects[1]);
                ChocoPuzzleObjects[2].SetActive(true);
                break;
            case CurrPanels.StirringChoco:
                Destroy(ChocoPuzzleObjects[2]);
                ChocoPuzzleObjects[3].SetActive(true);
                break;
            case CurrPanels.FillingTart:
                Destroy(ChocoPuzzleObjects[3]);
                ChocoPuzzleObjects[4].SetActive(true);
                break;
            case CurrPanels.PlacingChoco:
                Destroy(ChocoPuzzleObjects[4]);
                ChocoPuzzleObjects[5].SetActive(true);
                break;
            case CurrPanels.Packing:
                Destroy(ChocoPuzzleObjects[5]);
                ChocoPuzzleObjects[6].SetActive(true);
                break;
            case CurrPanels.AllFinished:
                Destroy(ChocoPuzzleObjects[6]);
                
                break;
        }

    }

    public void DragObject( GameObject objectToDrag, bool isLocked)
    {
        if (!isLocked)
        {
            objectToDrag.transform.position = Input.mousePosition;

        }


    }

    public void DropObject(GameObject objectToDrag, GameObject objectDragToPos, float DropDistance, bool isLocked, Vector2 objectInitPos)
    {
        float Distance = Vector3.Distance(objectToDrag.transform.position, objectDragToPos.transform.position);
        if (Distance < DropDistance)
        {
            isLocked = true;
            objectToDrag.transform.position = objectDragToPos.transform.position;
            //PuzzleCanvas.enabled = false;
            charactorController.isInteracting = false;
            //theNextPanel.SetActive(true);
            Debug.Log("Puzzle Solved");

        }
        else
        {
            objectToDrag.transform.position = objectInitPos;

        }

    }
}
