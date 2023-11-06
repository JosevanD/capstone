using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragNDropCard : MonoBehaviour
{
    private RPSManager rpsManager;
    public string MyChoice;

    public GameObject objectToDrag;
    public GameObject objectDragToPos;
    private bool isLocked;
    public float DropDistance;
    public Image PlayerChoice;
    public Sprite EmptyCard;

    [Header("Card Puzzle Canvas")]
    public Canvas RPSCanvas;
    
    Vector2 objectInitPos;

    public void Start()
    {
        isLocked = false;
        rpsManager = FindObjectOfType<RPSManager>();
        objectInitPos = objectToDrag.transform.position;
    }
    public void DragObject(BaseEventData data)
    {

        PointerEventData pointerData = (PointerEventData)data;
        Vector2 position;

        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)RPSCanvas.transform,
            pointerData.position,
            RPSCanvas.worldCamera,
            out position
            );
        if (!isLocked)
        {

            transform.position = RPSCanvas.transform.TransformPoint(position);

        }
        
        //Debug.Log("Dragging");
        /*if (!isLocked)
        {

            objectToDrag.transform.position = Input.mousePosition;

        }*/


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
            
            PlayerChoice.sprite = gameObject.GetComponent<Image>().sprite;
            gameObject.GetComponent<Image>().enabled = false;
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
        gameObject.GetComponent<Image>().enabled = true;
        PlayerChoice.sprite = EmptyCard;
        rpsManager.AIChoice.sprite = EmptyCard;
        objectToDrag.transform.position = objectInitPos;
        isLocked = false;
        //rpsManager.AIChoice.sprite = null;
        rpsManager.Result.text = "Choose your Card";

    }
}
