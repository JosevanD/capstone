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

    
    private ChocoPuzzleManager chocoPuzzleManager;

    public float DropDistance;

    public bool isLocked = false;

    public bool isHeated = false;

    public Vector2 TargetPos2;

    Vector2 objectInitPos;

    public Charactor_Controller charactorController;


    void Start()
    {
        objectInitPos = objectToDrag.transform.position;
        TargetPos2 = objectInitPos;
        chocoPuzzleManager = FindObjectOfType<ChocoPuzzleManager>();
        switchingOven = FindObjectOfType<SwitchingOven>();

        //charactorController = FindObjectOfType<Charactor_Controller>();

    }

    public void DragObject()
    {
        chocoPuzzleManager.cursorManager.ChangeToGrab();
        //Debug.Log("Dragging");
        if (!isLocked)
        {
            
            objectToDrag.transform.position = Input.mousePosition; 
            
        }
    
    
    }

    public void DropObject()
    {
        chocoPuzzleManager.cursorManager.ChangeToPalm();
        float Distance = Vector3.Distance(objectToDrag.transform.position, objectDragToPos.transform.position);
        if (!isHeated)
        {
            if (Distance < DropDistance)
            {
                isLocked = true;
                objectToDrag.transform.position = objectDragToPos.transform.position;
               
                switchingOven.ObjsInPosition++;
                //ObjParent.SetActive(false);
                gameObject.SetActive(false);
                
            }
            else
            {
                objectToDrag.transform.position = objectInitPos;
               
            }

        }
        else if (isHeated)
        {
            

            //if (Distance < DropDistance)
            float Distance2 = Vector3.Distance(objectToDrag.transform.position, TargetPos2);
            if (Distance2 < DropDistance)
            {
                isLocked = true;
                objectToDrag.transform.position = TargetPos2;

                switchingOven.ObjsInPosition++;
                gameObject.SetActive(false);
            }
        }
        
    
    }
    private void Update()
    {
        //Debug.Log("is locked" + isLocked);

        if (isHeated)
            isLocked = false;
    }
}
