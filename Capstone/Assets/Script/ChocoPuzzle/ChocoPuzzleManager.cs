using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


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

    private SceneTracker sceneTracker;

    public Canvas ChocoPuzzleCanvas;
    [HideInInspector]
    public Charactor_Controller charactorController;
    [HideInInspector]
    public CursorManager cursorManager;


    public GameObject[] ChocoPuzzleObjects;
    public GameObject LevelCompleteTrggerObj;

    public int ChocoPuzzleObjectsNum;
    public bool IsPanelFinished;
    public int ChocolatesPlaced;
    public CurrPanels currPanels;
    public int MaxEndingTime;

    [Header("Text Mesh")]
    public TMP_Text TextObj;

    public string[] textContents;

    
   

    [Header("Ending SFX")]
    public AudioSource EndingAudioSource;
    public AudioClip EndingClip;

    private void Start()
    {
        sceneTracker = FindObjectOfType<SceneTracker>();
        LevelCompleteTrggerObj.SetActive(false);
        ChocolatesPlaced = 0;
        ChocoPuzzleObjectsNum = 0;
        charactorController = FindObjectOfType<Charactor_Controller>();
        cursorManager = FindObjectOfType<CursorManager>();
        ChocoPuzzleObjects[ChocoPuzzleObjectsNum].SetActive(true);
        Debug.Log("Panel Number 0 is " + ChocoPuzzleObjectsNum);
        Debug.Log("IsPanelfinished " + IsPanelFinished);
        currPanels = CurrPanels.BreakingChoco;
        IsPanelFinished = false;
        
    }

    private void Update()
    {

        switch (currPanels)
        {
            case CurrPanels.BreakingChoco:

                //TextObj.text = textContents[0];

                ChocoPuzzleObjects[0].SetActive(true);
                break;
            case CurrPanels.MixingMatcha:

                //TextObj.text = textContents[1];

                Destroy(ChocoPuzzleObjects[0]);
                ChocoPuzzleObjects[1].SetActive(true);
                break;
            case CurrPanels.Oven:

                //TextObj.text = textContents[2];

                Destroy(ChocoPuzzleObjects[1]);
                ChocoPuzzleObjects[2].SetActive(true);
                break;
            case CurrPanels.StirringChoco:

                //TextObj.text = textContents[3];

                Destroy(ChocoPuzzleObjects[2]);
                ChocoPuzzleObjects[3].SetActive(true);
                break;
            case CurrPanels.FillingTart:

                //TextObj.text = textContents[4];

                Destroy(ChocoPuzzleObjects[3]);
                ChocoPuzzleObjects[4].SetActive(true);
                break;
            case CurrPanels.Packing:

                //TextObj.text = textContents[5];

                Destroy(ChocoPuzzleObjects[4]);
                ChocoPuzzleObjects[5].SetActive(true);
                break;
            case CurrPanels.AllFinished:

                TextObj.text = null;
                sceneTracker.RewardCollected();
                Destroy(ChocoPuzzleObjects[5]);
                LevelCompleteTrggerObj.SetActive(true);
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

    public void SwitchInstruction(TMP_Text TextObj, string newText)
    {
        TextObj.text = newText;


    }

    

}
