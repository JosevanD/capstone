using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class Scratch2 : MonoBehaviour
{
    [SerializeField]
    [Header("Brushing Puzzle Canvas")]
    private GameObject BrushingPuzzleCanvasObj;
    [SerializeField]
    [Header("Brushing Puzzle interactable object")]
    private GameObject BrushingPuzzleInteractableObj;

    private Charactor_Controller charactorController;
    public int MaxEndingTime;
    public GameObject maskPrefab;
    public GameObject[] DetectionObjs;
    private bool isPressed = false;
    public int totalDetection;
    public int DetectionCount;
    //public CinemachineVirtualCamera BrushCam;
    public Camera MainCam;
    public Camera BrushCam;
     
    // Start is called before the first frame update
    void Start()
    {
        totalDetection = DetectionObjs.Length;
        DetectionCount = 0;
        charactorController = FindObjectOfType<Charactor_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DetectionCount == 0) 
        {
            //MainCam.enabled = false;
            BrushCam.enabled = true;
        }
        var mousePos = Input.mousePosition;
        mousePos.z = 5;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        if (isPressed == true)
        {
            GameObject maskSprite = Instantiate(maskPrefab, mousePos, Quaternion.identity);
            maskSprite.transform.parent = gameObject.transform;

        }
        
        if (Input.GetMouseButton(0))
        {
            isPressed = true;
            //Invoke("Reveal", 10);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isPressed = false;
        }

        if (DetectionCount/ totalDetection >= 0.7f )
        {
            
            Reveal();
        }

    }

    void Reveal()
    {
        //Destroy(gameObject);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(Countdown(MaxEndingTime));
       
    }

    IEnumerator Countdown(int seconds)
    {
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }
        MainCam.enabled = true;
        BrushCam.enabled = false;
        BrushingPuzzleCanvasObj.SetActive(false);
        BrushingPuzzleInteractableObj.SetActive(false);
        charactorController.isInteracting = false;



    }
}
