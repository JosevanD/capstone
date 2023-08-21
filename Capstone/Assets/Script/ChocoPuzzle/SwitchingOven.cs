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

    public Button CurrentButton;
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

    // Start is called before the first frame update
    void Start()
    {
        chocoPuzzleManager = FindObjectOfType<ChocoPuzzleManager>();
        ObjMatchaParent.SetActive(false);
        isOpened = false;
        isHeating = false;
        isInOven = false;
        isFinishedHeating = false;
    }

    public void OnPointerDownPutIN()
    {
        //Sprite CurrentSprite;
        if (isOpened = true && isInOven == false)
        {
            CurrentButton.image.sprite = OvenClosedSprite;
            CurrentButton.interactable = false;
            //isHeating = true;
            isOpened = false;

        }
        if (isOpened == false && isInOven == false)
        {
            CurrentButton.image.sprite = OvenOpenedSprite;
            CurrentButton.interactable = false;
            ObjMatchaParent.SetActive(true);
            isOpened = true;
        }
        if (isOpened == false && isInOven == true)
        {
            CurrentButton.image.sprite = OvenClosedSprite;
            CurrentButton.interactable = false;
            //ObjMatchaParent.SetActive(true);
            isHeating = true;
            isOpened = false;

        }
        if (isOpened == true && isFinishedHeating)
        {
            CurrentButton.image.sprite = OvenOpenedSprite;
            CurrentButton.interactable = false;
            Chocolatebowl.GetComponent<Image>().sprite = MeltedChocoSprite;

            StartCoroutine(Countdown(chocoPuzzleManager.MaxEndingTime));

            isOpened = true;
        }

        /*if (ImageCount < Images.Length - 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ImageCount++;
                Images[ImageCount].SetActive(true);

                Debug.Log("Current Image No is " + ImageCount);

                Images[ImageCount - 1].SetActive(false);

                Debug.Log("last Image No is " + ImageCount);




            }
            if (ImageCount >= Images.Length - 1)
            {
                Debug.Log("Oven opened / closed");

                
            }

        }*/
        //CurrentSprite = OvenOpenedSprite;

        //ObjMatchaParent.SetActive(true);
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
            CurrentButton.interactable = true;
            Debug.Log("Heating Finished " );
        }
    }
}
