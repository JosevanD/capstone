using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraPuzzleManager : MonoBehaviour
{
    CamCursorCollision camCursorCollision;
    CameraFlash camFlash;

    [Header("Instruction")]
    public GameObject CamPuzzleInstruction;

    public Animator InnerBoxAnimator;
    public GameObject PlayerObj;
    public GameObject AcompanyCharacter;

    public GameObject CorrectPhoto;
    public GameObject WrongPhoto;

    public GameObject DoorPrefab;

    [Header("Cam SFX")]
    private AudioSource CamAudio;
    public AudioClip FlashingSFX;

    private bool isShotCool;
    private bool isCorrectPhoto;

    private SceneTracker sceneTracker;

    // Start is called before the first frame update
    void Start()
    {
        CamPuzzleInstruction.SetActive(true);
        CamAudio = GetComponent<AudioSource>();
        camCursorCollision = FindObjectOfType<CamCursorCollision>();
        camFlash = FindObjectOfType<CameraFlash>();
        isShotCool = true;
        AcompanyCharacter.SetActive(false);
        PlayerObj.SetActive(false);
        sceneTracker = FindObjectOfType<SceneTracker>();
        //InnerBoxAnimator.SetBool("isHorizontal", true);

    }

    // Update is called once per frame
    void Update()
    {

        if (camCursorCollision.isCursorHit && Input.GetKeyDown(KeyCode.Mouse0) && isShotCool) 
        {
            //CorrectPhoto.SetActive(true);
            CamPuzzleInstruction.SetActive(false);
            CamAudio.PlayOneShot(FlashingSFX);
            isCorrectPhoto = true;
            StartCoroutine(PhotoOutputCountdown(1));
            StartCoroutine(PhotoCountdown(5));
            isShotCool = false;
            camFlash.cameraFlash();
            InnerBoxAnimator.SetBool("isFinished", true);

        }
        if (!camCursorCollision.isCursorHit && Input.GetKeyDown(KeyCode.Mouse0) && isShotCool)
        {
            CamAudio.PlayOneShot(FlashingSFX);
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
            sceneTracker.RewardCollected();
            PlayerObj.SetActive(true);
            AcompanyCharacter.SetActive(true);
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
