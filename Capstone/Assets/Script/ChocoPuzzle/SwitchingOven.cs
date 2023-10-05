using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchingOven : MonoBehaviour
{
    //public GameObject Matcha;
    public GameObject ObjMatchaParent;

    public GameObject theNextPanel;
    public GameObject theCurrPanel;
    private ChocoPuzzleManager chocoPuzzleManager;

    
    public Sprite OvenOpenedSprite;
    public Sprite OvenClosedSprite;
    public GameObject Chocolatebowl;
    public Sprite MeltedChocoSprite;

    public bool isOpened;
    public bool isHeating;
    public bool isInOven;
    private bool isFinishedHeating;
    public float TotalWaitingTime;
    private float CurrWaitingTime;
    //public GameObject OvenDoor;
    private int ImageCount = 0;

    private DragNDropOven dragNDropOven;

    [Header("Microwave Game objects ")]
    public GameObject MicrowaveClosedObj;
    public GameObject MicrowaveOpenedObj;

    [Header("Microwave Images ")]
    public Sprite CloseOffRed, CloseOnRed, CloseOnGreen, OpenOffRed, OpenoffFood, OpenOnGreen;



    [Header("Microwave Button")]
    public Button MicrowaveClosedButton;
    public Button MicrowaveOpenedButton;

    [Header("Microwave SFX")]
    public AudioSource MicrowaveAudioSource;
    public AudioClip MicrowaveClip;

    // Start is called before the first frame update
    void Start()
    {
        chocoPuzzleManager = FindObjectOfType<ChocoPuzzleManager>();
        dragNDropOven = FindObjectOfType<DragNDropOven>();
        MicrowaveAudioSource = GetComponent<AudioSource>();
        ObjMatchaParent.SetActive(false);
        isOpened = false;
        isHeating = false;
        isInOven = false;
        isFinishedHeating = false;
    }

    public void OnPointerDownPutIN()
    {
        //Sprite CurrentSprite;
        //opened without food inside
        if (isOpened = true && isInOven == false)
        {
            //CurrentButton.image.sprite = OvenClosedSprite;
            MicrowaveOpenedObj.SetActive(false);
            MicrowaveClosedObj.SetActive(true);
            MicrowaveClosedObj.GetComponent<Image>().sprite = CloseOffRed;
            //CurrentButton.interactable = false;
            //MicrowaveClosedObj.GetComponent<Button>().interactable = false;
            //isHeating = true;
            isOpened = false;

        }
        if (isOpened == false && isInOven == false)
        {
            //CurrentButton.image.sprite = OvenOpenedSprite;
            MicrowaveClosedObj.SetActive(false);
            MicrowaveOpenedObj.SetActive(true);
           // MicrowaveOpenedObj.GetComponent<Button>().interactable = false;
            MicrowaveOpenedObj.GetComponent<Image>().sprite = OpenOffRed;
            //CurrentButton.interactable = false;
            ObjMatchaParent.SetActive(true);
            isOpened = true;
        }
        

        if (isOpened == false && isInOven == true)
        {
            //CurrentButton.image.sprite = OvenClosedSprite;

            MicrowaveOpenedObj.SetActive(false);
            MicrowaveClosedObj.SetActive(true);
            MicrowaveClosedObj.GetComponent<Image>().sprite = CloseOnRed;
            //MicrowaveClosedObj.GetComponent<Button>().interactable = false;
            //CurrentButton.interactable = false;
            MicrowaveAudioSource.PlayOneShot(MicrowaveClip);
            //ObjMatchaParent.SetActive(true);
            isHeating = true;
            isOpened = false;

        }
        if (isOpened == true && isFinishedHeating)
        {
            //CurrentButton.image.sprite = OvenOpenedSprite;

            MicrowaveClosedObj.SetActive(false);
            MicrowaveOpenedObj.SetActive(true);
            MicrowaveOpenedObj.GetComponent<Button>().interactable = false;

            MicrowaveOpenedObj.GetComponent<Image>().sprite = OpenoffFood;
            
            dragNDropOven.isHeated = true;
            dragNDropOven.isLocked = false;
            //StartCoroutine(Countdown(chocoPuzzleManager.MaxEndingTime));

            isOpened = true;
        }

    }

    IEnumerator Countdown(int seconds)
    {
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }

        chocoPuzzleManager.ChocoPuzzleCanvas.enabled = false;
        chocoPuzzleManager.charactorController.isInteracting = false;
        chocoPuzzleManager.currPanels = ChocoPuzzleManager.CurrPanels.StirringChoco;
        theCurrPanel.SetActive(false);


    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log("isInOven " + isInOven + "isOPen" + isOpened);

        if (isHeating && isInOven)
        {
            CurrWaitingTime += Time.deltaTime;
            Debug.Log("CurrentWaitingTime" + CurrWaitingTime);
        
        }
        if (CurrWaitingTime >= TotalWaitingTime)
        {
            isHeating = false;
            isInOven = false;
            isFinishedHeating = true;
            MicrowaveOpenedObj.SetActive(false);
            MicrowaveClosedObj.SetActive(true);
            MicrowaveClosedObj.GetComponent<Image>().sprite = CloseOnGreen;
            //MicrowaveClosedObj.GetComponent<Button>().interactable = true;
            //CurrentButton.interactable = true;


            Debug.Log("Heating Finished " );
        }
    }
}
