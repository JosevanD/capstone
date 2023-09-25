using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDropCard : MonoBehaviour
{
    private RPSManager rpsManager;
    public string MyChoice;

    public GameObject objectToDrag;
    public GameObject objectDragToPos;
    private bool isLocked;
    public float DropDistance;
    
    
    Vector2 objectInitPos;

    public void Start()
    {
        rpsManager = FindObjectOfType<RPSManager>();
        objectInitPos = objectToDrag.transform.position;
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
            rpsManager.Play(MyChoice);
            Debug.Log("in position");
            Invoke("SendBackCards", rpsManager.WaitForSeconds);
            //Destroy(gameObject);

        }
        else
        {
            objectToDrag.transform.position = objectInitPos;

        }

    }
    void SendBackCards()
    {
        objectToDrag.transform.position = objectInitPos;
        isLocked = false;
        rpsManager.AIChoice.sprite = null;
        rpsManager.Result.text = "Choose your Card";

    }
}
