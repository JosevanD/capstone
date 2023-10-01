using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragNDropForChocoPieces : MonoBehaviour
{
    public GameObject objectToDrag;
    public GameObject objectDragToPos;
    private BreakingChocoPieces breakingChocoPieces;
    private ChocoPuzzleManager chocoPuzzleManager;

    [Header("Chocolate Bowl")]
    public GameObject ChocolateBowl;
    public Sprite FilledChocolateBowl;
    //private ChocoPuzzleManager chocoPuzzleManager;
    public float DropDistance;


    public bool isLocked = false;


    Vector2 objectInitPos;
    // Start is called before the first frame update
    void Start()
    {
        objectInitPos = objectToDrag.transform.position;

        //charactorController = FindObjectOfType<Charactor_Controller>();
        chocoPuzzleManager = FindObjectOfType<ChocoPuzzleManager>();
        breakingChocoPieces = FindObjectOfType<BreakingChocoPieces>();
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
            ChocolateBowl.GetComponent<Image>().sprite = FilledChocolateBowl;
            
            StartCoroutine(breakingChocoPieces.Countdown(chocoPuzzleManager.MaxEndingTime));
            gameObject.GetComponent<Image>().enabled = false;
            //Destroy(gameObject);

        }
        else
        {
            objectToDrag.transform.position = objectInitPos;

        }

    }
}
