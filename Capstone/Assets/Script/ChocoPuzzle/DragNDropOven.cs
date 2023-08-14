using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragNDropOven : MonoBehaviour
{
    public GameObject objectToDrag;
    public GameObject objectDragToPos;
    //public GameObject theNextPanel;
    //public GameObject theCurrPanel;
    public GameObject ObjParent;
    private SwitchingOven switchingOven;

    public Button theOvenButton;
    private ChocoPuzzleManager chocoPuzzleManager;
    public float DropDistance;

    public bool isLocked = false;


    Vector2 objectInitPos;

    public Charactor_Controller charactorController;

    //[Header("The Puzzle Canvas")]
    //public Canvas PuzzleCanvas;
    // Start is called before the first frame update
    void Start()
    {
        objectInitPos = objectToDrag.transform.position;
        chocoPuzzleManager = FindObjectOfType<ChocoPuzzleManager>();
        switchingOven = FindObjectOfType<SwitchingOven>();
        //charactorController = FindObjectOfType<Charactor_Controller>();

    }

    public void DragObject()
    {
        if (!isLocked)
        {
            Debug.Log("Dragging");
            objectToDrag.transform.position = Input.mousePosition; 
            
        }
    
    
    }

    public void DropObject()
    {
        float Distance = Vector3.Distance(objectToDrag.transform.position, objectDragToPos.transform.position);
        if (Distance < DropDistance)
        {
            isLocked = true;
            objectToDrag.transform.position = objectDragToPos.transform.position;
            //PuzzleCanvas.enabled = false;
            //chocoPuzzleManager.ChocoPuzzleCanvas.enabled = false;
            //chocoPuzzleManager.charactorController.isInteracting = false;
            
            //theNextPanel.SetActive(true);
            //theCurrPanel.SetActive(false);
            theOvenButton.interactable = true;
            switchingOven.isInOven = true;
            switchingOven.isOpened = true;
            Debug.Log("Puzzle Solved");
            ObjParent.SetActive(false);

        }
        else 
        {
            objectToDrag.transform.position = objectInitPos;
        
        }
    
    }
}
