using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNDforPlacing : MonoBehaviour
{
    public GameObject objectToDrag;
    public GameObject objectDragToPos;
    public GameObject theNextPanel;
    public GameObject theCurrPenel;
    private ChocoPuzzleManager chocoPuzzleManager;
    public float DropDistance;


    public bool isLocked = false;


    Vector2 objectInitPos;

    //public Charactor_Controller charactorController;

    //[Header("The Puzzle Canvas")]
    public Canvas PuzzleCanvas;
    // Start is called before the first frame update
    void Start()
    {
        objectInitPos = objectToDrag.transform.position;

        //charactorController = FindObjectOfType<Charactor_Controller>();
        chocoPuzzleManager = FindObjectOfType<ChocoPuzzleManager>();
    }

    public void DragObject()
    {
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
            //charactorController.isInteracting = false;
            //theNextPanel.SetActive(true);
            chocoPuzzleManager.ChocolatesPlaced += 1;
            Debug.Log("1 Choco Placed");

        }
        else
        {
            objectToDrag.transform.position = objectInitPos;

        }

    }
    private void Update()
    {
        if (chocoPuzzleManager.ChocolatesPlaced >= 4)
        {
            theNextPanel.SetActive(true);
            theCurrPenel.SetActive(false);
        }
    }
}
