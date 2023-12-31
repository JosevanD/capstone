using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class CutsceneClick : MonoBehaviour
{
    [Header("Cutscene Parameters")]
    [SerializeField] GameObject[] cutsceneObjects;
    [SerializeField] float[] cutsceneTimes;
    [SerializeField] int i = 0;
    [SerializeField] bool canClick = false;
    [SerializeField] GameObject advanceUI;
    [SerializeField] GameObject objToActivate;
    [SerializeField] bool hasObjToActivate;
    private int arrayLength;
    [SerializeField] private GameObject playerObj;

    //[Header("Cutscene Video System")]

    //[SerializeField] private

    [Header("Audio")]

    [SerializeField] private GameObject bgAudioObject;
    [SerializeField] private int audioNo;
    [SerializeField] bool isChangeAudio;
    [SerializeField] private int previousAudioNo;

    [Header("Fade")]

    [SerializeField] private float fadeOutTime;
    [SerializeField] private Animator fadeAnimator;

    // Start is called before the first frame update
    void Start()
    {
      
    }
    private void OnEnable()
    {
        //Audio
        if (isChangeAudio == true)
        {
            bgAudioObject = GameObject.FindGameObjectWithTag("BG Audio Controller");
            bgAudioObject.GetComponent<BackgroundAudioController>().ChangeAudio(audioNo);
        }

        bgAudioObject.GetComponent<BackgroundAudioController>().TurnOffSfx();
        //Set Array and Timer
        arrayLength = cutsceneObjects.Length;
        StartCoroutine(CutsceneCounter(cutsceneTimes[i]));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canClick == true && i < (arrayLength - 1))
        {
            CutsceneClickAdv();
            canClick = false;
        }

        
    }

    public void CutsceneClickAdv()
    {
            advanceUI.SetActive(false);
            
            i++;
            //StartCoroutine(CutsceneOnDelay(0.25f));
            cutsceneObjects[i].SetActive(true);
            //cutsceneObjects[i-1].SetActive(false);
            StartCoroutine(CutsceneOffDelay(0.5f));
            StartCoroutine(CutsceneCounter(cutsceneTimes[i]));
            
    }

    IEnumerator CutsceneCounter(float time)
    {
        yield return new WaitForSeconds(time);
        canClick = true;
        advanceUI.SetActive(true);

        if (i == (arrayLength - 1))
        {
            if (hasObjToActivate == true)
            {
                objToActivate.SetActive(true);
            }
            bgAudioObject.GetComponent<BackgroundAudioController>().TurnOnSfx();
            advanceUI.SetActive(false);

            StartCoroutine(CutsceneFadeOut(fadeOutTime));
            
        }
    }

    IEnumerator CutsceneFadeOut(float time)
    {
        fadeAnimator.SetBool("fadeout", true);
        yield return new WaitForSeconds(time);
        CutsceneReset();
        changeBackAudio();
        gameObject.SetActive(false);
    }

    public void CutsceneStopPlayer()
    {
        if (playerObj != null)
        {
            playerObj.SetActive(false);
        }
        
    }

    public void CustceneActivatePlayer()
    {
        if (playerObj != null)
        {
            playerObj.SetActive(true);
        }
    }

    private void CutsceneReset()
    {
        canClick = false;
        cutsceneObjects[i].SetActive(false);
        i = 0;
        cutsceneObjects[i].SetActive(true);
       
        
        
        
    }

    private void changeBackAudio()
    {
        if (isChangeAudio == true)
        {
            bgAudioObject.GetComponent<BackgroundAudioController>().ChangeAudio(previousAudioNo);
        }
    }
    
    IEnumerator CutsceneOffDelay(float time)
    {
        yield return new WaitForSeconds(time);
        cutsceneObjects[i - 1].SetActive(false);
    }
    IEnumerator CutsceneOnDelay(float time)
    {
        yield return new WaitForSeconds(time);
        cutsceneObjects[i].SetActive(true);
    }
}
