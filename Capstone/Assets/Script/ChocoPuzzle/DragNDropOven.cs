using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragNDropOven : MonoBehaviour
{
    public GameObject objectToDrag;
    public GameObject objectDragToPos;

    public GameObject ObjParent;
    private SwitchingOven switchingOven;

    public Button theOvenButton;
    private ChocoPuzzleManager chocoPuzzleManager;
    public float DropDistance;

    public bool isLocked = false;

    public bool isHeated = false;

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
        //Debug.Log("Dragging");
        if (!isLocked)
        {
            
            objectToDrag.transform.position = Input.mousePosition; 
            
        }
    
    
    }

    public void DropObject()
    {
        float Distance = Vector3.Distance(objectToDrag.transform.position, objectDragToPos.transform.position);
        if (!isHeated)
        {
            if (Distance < DropDistance)
            {
                isLocked = true;
                objectToDrag.transform.position = objectDragToPos.transform.position;
                theOvenButton.interactable = true;
                switchingOven.isInOven = true;
                switchingOven.isOpened = true;
                switchingOven.MicrowaveOpenedObj.GetComponent<Image>().sprite = switchingOven.OpenoffFood;

                ObjParent.SetActive(false);

            }
            else
            {
                objectToDrag.transform.position = objectInitPos;

            }

        }
        else if (isHeated)
        {
            objectDragToPos.transform.position = objectInitPos;

            //if (Distance < DropDistance)

        }
        
    
    }
    private void Update()
    {
        //Debug.Log("is locked" + isLocked);
    }
}
