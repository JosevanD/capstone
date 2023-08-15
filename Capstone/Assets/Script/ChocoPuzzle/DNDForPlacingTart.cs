using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DNDForPlacingTart : MonoBehaviour
{
    public GameObject objectToDrag;
    public GameObject objectDragToPos;
    //public GameObject ObjParent;
    private ChocoPuzzleManager chocoPuzzleManager;
    private PackingManager packingManager;
    public float DropDistance;

    public bool isLocked = false;


    Vector2 objectInitPos;
    // Start is called before the first frame update
    void Start()
    {
        packingManager = FindObjectOfType<PackingManager>();

        objectInitPos = objectToDrag.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if (Distance < DropDistance)
        {
            isLocked = true;
            objectToDrag.transform.position = objectDragToPos.transform.position;
            //PuzzleCanvas.enabled = false;
            //chocoPuzzleManager.ChocoPuzzleCanvas.enabled = false;
            //chocoPuzzleManager.charactorController.isInteracting = false;

            //theNextPanel.SetActive(true);
            //theCurrPanel.SetActive(false);
            //Debug.Log("Puzzle Solved");
            //ObjParent.SetActive(false);
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
