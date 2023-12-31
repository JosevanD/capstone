using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SwitchingOven : MonoBehaviour
{
    //public GameObject Matcha;
    public GameObject ObjMatchaParent;
    public GameObject ObjMatcha;
    public GameObject ObjChoco;
    public GameObject MatchaInMicro;
    public GameObject ChocoInMicro;
    public int ObjsInPosition;

    public Sprite hotMatcha;
    public Sprite hotChoco;


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
    public bool isFinished;
    public float TotalWaitingTime;
    public bool isInPosition1;
    public bool isInPosition2;
    private bool isTwoObjInPosition;
    private float CurrWaitingTime;
    //public GameObject OvenDoor;
    private int ImageCount = 0;

    private DragNDropOven dragNDropOven;

    public Button theOvenButton;

    [Header("Microwave Game objects ")]
    public GameObject MicrowaveClosedObj;
    public GameObject MicrowaveOpenedObj;

    [Header("Microwave Images ")]
    public Sprite CloseOffRed, CloseOnRed, CloseOnGreen,OpenOffRedMatcha,OpenOffRedMatchaChoco, OpenOffRed, OpenOffFood, OpenOnGreen;



    [Header("Microwave Button")]
    public Button MicrowaveClosedButton;
    public Button MicrowaveOpenedButton;

    [Header("Microwave SFX")]
    public AudioSource MicrowaveAudioSource;
    public AudioClip MicrowaveClip;

    [Header("Instruction")]
    public TMP_Text TextObj;
    public string Instruction_1;
    public string Instruction_2;
    public string Instruction_3;
    public string Instruction_4;


    // Start is called before the first frame update
    void Start()
    {
        ObjsInPosition = 0;
        chocoPuzzleManager = FindObjectOfType<ChocoPuzzleManager>();
        dragNDropOven = FindObjectOfType<DragNDropOven>();
        MicrowaveAudioSource = GetComponent<AudioSource>();
        ObjMatchaParent.SetActive(false);
        isOpened = false;
        isHeating = false;
        isInOven = false;
        isFinishedHeating = false;
        isFinished = false;
        isTwoObjInPosition = true;
        chocoPuzzleManager.SwitchInstruction(TextObj, Instruction_1);
        chocoPuzzleManager.cursorManager.SetCursorDefault();

    }

    public void OnPointerDownPutIN()
    {
        //opened without food inside
        if (isOpened = true && isInOven == false && isFinishedHeating == false)
        {
            Debug.Log("1");
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
            Debug.Log("2");
            chocoPuzzleManager.SwitchInstruction(TextObj, Instruction_2);
            MicrowaveClosedObj.SetActive(false);
            MicrowaveOpenedObj.SetActive(true);
           // MicrowaveOpenedObj.GetComponent<Button>().interactable = false;
            MicrowaveOpenedObj.GetComponent<Image>().sprite = OpenOffRed;
            //CurrentButton.interactable = false;
            ObjMatchaParent.SetActive(true);
            isOpened = true;
            chocoPuzzleManager.cursorManager.ChangeToPalm();
        }
        

        if (isOpened == false && isInOven == true && isHeating == false && ObjsInPosition == 2)
        {
            chocoPuzzleManager.SwitchInstruction(TextObj, Instruction_3);
            //CurrentButton.image.sprite = OvenClosedSprite;
            Debug.Log("3");
            MicrowaveOpenedObj.SetActive(false);
            MicrowaveClosedObj.SetActive(true);
            MicrowaveClosedObj.GetComponent<Image>().sprite = CloseOnRed;
            //MicrowaveClosedObj.GetComponent<Button>().interactable = false;
            //CurrentButton.interactable = false;
            MicrowaveAudioSource.PlayOneShot(MicrowaveClip);
            //ObjMatchaParent.SetActive(true);
            isHeating = true;
            isOpened = false;
            isTwoObjInPosition = false;

        }
        if (isOpened == false && isInOven == true && isHeating == true)
        {
            isFinishedHeating = true;

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
            //Debug.Log("CurrentWaitingTime" + CurrWaitingTime);
        
        }
        if (CurrWaitingTime >= TotalWaitingTime && isFinishedHeating == true)
        {
            chocoPuzzleManager.SwitchInstruction(TextObj, Instruction_4);
            ObjChoco.GetComponent<Image>().sprite = hotChoco;
            ObjMatcha.GetComponent<Image>().sprite = hotMatcha;
            ObjChoco.GetComponent<Image>().SetNativeSize();
            ObjMatcha.GetComponent<Image>().SetNativeSize();
            ObjChoco.SetActive(true);
            ObjMatcha.SetActive(true);
            isHeating = false;
            isInOven = false;

            ObjMatcha.GetComponent<DragNDropOven>().isLocked = false;
            ObjChoco.GetComponent<DragNDropOven>().isLocked = false;
            ObjMatcha.GetComponent<DragNDropOven>().isHeated= true;
            ObjChoco.GetComponent<DragNDropOven>().isHeated = true;
            MicrowaveClosedObj.SetActive(false);
            MicrowaveOpenedObj.SetActive(true);

            MicrowaveOpenedObj.GetComponent<Image>().sprite = OpenOnGreen;
            MicrowaveOpenedObj.GetComponent<Button>().interactable = false;

            
        }

        if (isTwoObjInPosition == false)
        {
            ObjMatcha.transform.position = MatchaInMicro.transform.position;
            ObjChoco.transform.position = ChocoInMicro.transform.position;
            isTwoObjInPosition = true;
        }
        if (ObjsInPosition == 1)
        {
            MicrowaveOpenedObj.GetComponent<Image>().sprite = OpenOffRedMatcha;
            ObjChoco.GetComponent<Image>().raycastTarget = true;
        }

        if (ObjsInPosition == 2 && isFinishedHeating == false)
        {
            theOvenButton.interactable = true;
            isInOven = true;
            isOpened = true;
            MicrowaveOpenedObj.GetComponent<Image>().sprite = OpenOffRedMatchaChoco;
        }
        if (ObjsInPosition == 4)
        {
            isFinished = true;
        }

        if (isFinished == true)
        {
            chocoPuzzleManager.cursorManager.SetCursorDefault();
            chocoPuzzleManager.EndingAudioSource.Stop();
            chocoPuzzleManager.EndingAudioSource.PlayOneShot(chocoPuzzleManager.EndingClip);
            StartCoroutine(Countdown(chocoPuzzleManager.MaxEndingTime));

        }
        

    }
}
