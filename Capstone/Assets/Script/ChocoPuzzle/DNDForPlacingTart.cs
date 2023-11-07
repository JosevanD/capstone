using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DNDForPlacingTart : MonoBehaviour
{
    public GameObject objectToDrag;
    public GameObject objectDragToPos;


    private ChocoPuzzleManager chocoPuzzleManager;
    private PackingManager packingManager;
    public float DropDistance;

    public bool isLocked = false;


    Vector2 objectInitPos;

    void Start()
    {
        packingManager = FindObjectOfType<PackingManager>();
        chocoPuzzleManager = FindObjectOfType<ChocoPuzzleManager>();
        objectInitPos = objectToDrag.transform.position;
    }

    void Update()
    {
        
    }

    public void DragObject()
    {

        if (!isLocked)
        {
            chocoPuzzleManager.cursorManager.ChangeToGrab();
            objectToDrag.transform.position = Input.mousePosition;

        }


    }

    public void DropObject()
    {
        chocoPuzzleManager.cursorManager.ChangeToPalm();
        float Distance = Vector3.Distance(objectToDrag.transform.position, objectDragToPos.transform.position);
        if (Distance < DropDistance)
        {
            isLocked = true;
            objectToDrag.transform.position = objectDragToPos.transform.position;
            Debug.Log("in position");
            packingManager.currSpriteNum++;
            Destroy(gameObject);

        }
        else
        {
            objectToDrag.transform.position = objectInitPos;

        }

    }


}
