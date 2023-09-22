using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class Scratch2 : MonoBehaviour
{
    [SerializeField]
    [Header("Brushing UI Image")]    
    private GameObject BrushingUIImage;

    [SerializeField]
    [Header("Brushing Puzzle CanvasObj")]
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

    [Header("Protagonist Camera")]
    public CinemachineVirtualCamera ProtagonistCam;
    [Header("Door Camera")]
    public CinemachineVirtualCamera TargetCam;
    [Header("Protagonist Object")]
    public GameObject ProtagonistObject;
    [Header("Protagonist Object")]
    public GameObject SettingProtagonistObject;
    [Header("Max Time of the door Camera")]
    public float MaxCamTime;
    // Start is called before the first frame update
    private void Awake()
    {
        totalDetection = DetectionObjs.Length;
        DetectionCount = 0;
        charactorController = FindObjectOfType<Charactor_Controller>();
        //ProtagonistCam.LookAt = ProtagonistObject.transform;
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

        ProtagonistCam.Priority = 0;
        TargetCam.Priority = 1;
        StartCoroutine(StartObject(MaxCamTime));
        //turn off the UI
        BrushingUIImage.SetActive(false);
        //turn off the Protagonist
        SettingProtagonistObject.SetActive(false);
        MainCam.enabled = true;
        BrushCam.enabled = false;

    }

    IEnumerator StartObject(float time)
    {
        
        yield return new WaitForSeconds(time);

        ProtagonistCam.LookAt = ProtagonistObject.transform;
        ProtagonistCam.Priority = 1;
        TargetCam.Priority = 0;

        ProtagonistObject.SetActive(true);
        charactorController = FindObjectOfType<Charactor_Controller>();
        BrushingPuzzleCanvasObj.SetActive(false);
        BrushingPuzzleInteractableObj.SetActive(false);
        charactorController.isInteracting = false;

    }
}
