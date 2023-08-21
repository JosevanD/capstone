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
    public int MaxEndingTime;
    //private float EndingTimer;

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
        //EndingTimer = 0;
    }

    private void Update()
    {

        switch (currPanels)
        {
            case CurrPanels.BreakingChoco:
                ChocoPuzzleObjects[0].SetActive(true);
                break;
            case CurrPanels.MixingMatcha:
                //ChocoPuzzleObjects[0].SetActive(false);
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
            case CurrPanels.Packing:
                Destroy(ChocoPuzzleObjects[4]);
                ChocoPuzzleObjects[5].SetActive(true);
                break;
            case CurrPanels.AllFinished:
                Destroy(ChocoPuzzleObjects[5]);
                                
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
    
        /*public void PuzzleEndTimer(Canvas ChocoPuzzleCanvas, CharacterController charactorController, CurrPanels currPanels)
        {

            EndingTimer += Time.deltaTime;

            if (EndingTimer >= MaxEndingTime)
            {
                IsPanelFinished = false;
                EndingTimer = 0;
                ChocoPuzzleCanvas.enabled = false;
                charactorController.isInteracting = false;
                currPanels = ChocoPuzzleManager.CurrPanels.MixingMatcha;
                theCurrPanel.SetActive(false);

            }

        }*/

    }
