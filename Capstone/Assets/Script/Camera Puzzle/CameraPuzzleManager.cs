using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraPuzzleManager : MonoBehaviour
{
    CamCursorCollision camCursorCollision;
    CameraFlash camFlash;

    

    public GameObject CorrectPhoto;
    public GameObject WrongPhoto;

    private bool isShotCool;
    // Start is called before the first frame update
    void Start()
    {
        camCursorCollision = FindObjectOfType<CamCursorCollision>();
        camFlash = FindObjectOfType<CameraFlash>();
        isShotCool = true;

        
    }

    // Update is called once per frame
    void Update()
    {

        if (camCursorCollision.isCursorHit && Input.GetKeyDown(KeyCode.Mouse0) && isShotCool) 
        {
            CorrectPhoto.SetActive(true);
            StartCoroutine(CorrectPhotoCountdown(3));
            isShotCool = false;
            camFlash.cameraFlash();

        }
        if (!camCursorCollision.isCursorHit && Input.GetKeyDown(KeyCode.Mouse0) && isShotCool)
        {
            StartCoroutine(WrongPhotoCountdown(3));
            WrongPhoto.SetActive(true);
            isShotCool = false;
            camFlash.cameraFlash();
            //photo Animation can be implemented
        }
    }


    IEnumerator WrongPhotoCountdown(int seconds)
    {
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }
        Debug.Log("111");
        WrongPhoto.SetActive(false);
        isShotCool = true;

    }
    IEnumerator CorrectPhotoCountdown(int seconds)
    {
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }
        Debug.Log("222");
        gameObject.SetActive(false);


    }


}
