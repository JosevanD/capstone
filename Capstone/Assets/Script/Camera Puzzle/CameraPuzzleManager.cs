using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraPuzzleManager : MonoBehaviour
{
    CamCursorCollision camCursorCollision;
    CameraFlash camFlash;

    public Animator InnerBoxAnimator;
    public GameObject PlayerObj;
    public GameObject CompanyCharacter;

    public GameObject CorrectPhoto;
    public GameObject WrongPhoto;

    public GameObject DoorPrefab;

    private bool isShotCool;
    private bool isCorrectPhoto;
    // Start is called before the first frame update
    void Start()
    {
        camCursorCollision = FindObjectOfType<CamCursorCollision>();
        camFlash = FindObjectOfType<CameraFlash>();
        isShotCool = true;
        CompanyCharacter.SetActive(false);
        PlayerObj.SetActive(false);
        //InnerBoxAnimator.SetBool("isHorizontal", true);
        
    }

    // Update is called once per frame
    void Update()
    {

        if (camCursorCollision.isCursorHit && Input.GetKeyDown(KeyCode.Mouse0) && isShotCool) 
        {
            //CorrectPhoto.SetActive(true);
            isCorrectPhoto = true;
            StartCoroutine(PhotoOutputCountdown(1));
            StartCoroutine(PhotoCountdown(5));
            isShotCool = false;
            camFlash.cameraFlash();
            InnerBoxAnimator.SetBool("isIdle", true);

        }
        if (!camCursorCollision.isCursorHit && Input.GetKeyDown(KeyCode.Mouse0) && isShotCool)
        {
            isCorrectPhoto = false;
            StartCoroutine(PhotoOutputCountdown(1));
            StartCoroutine(PhotoCountdown(3));
            //WrongPhoto.SetActive(true);
            isShotCool = false;
            camFlash.cameraFlash();
            //photo Animation can be implemented
        }
    }


    IEnumerator PhotoCountdown(int seconds)
    {
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }
        Debug.Log("111");
        
        if (isCorrectPhoto)
        {
            PlayerObj.SetActive(true);
            CompanyCharacter.SetActive(true);
            DoorPrefab.SetActive(true);
            gameObject.SetActive(false);
        }
        if (!isCorrectPhoto)
        {
            WrongPhoto.SetActive(false);

        }
        isShotCool = true;

    }
    
    IEnumerator PhotoOutputCountdown(int seconds)
    {
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }
        if(isCorrectPhoto)
            CorrectPhoto.SetActive(true);
        if(!isCorrectPhoto)
            WrongPhoto.SetActive(true);


    }


}
