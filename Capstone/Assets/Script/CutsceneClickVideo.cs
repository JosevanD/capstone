using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Video;
public class CutsceneClickVideo : MonoBehaviour
{
    [Header("Cutscene Parameters")]
    //[SerializeField] GameObject[] cutsceneObjects;
    [SerializeField] GameObject cutsceneObject;
    
    [SerializeField] float[] cutsceneTimes;
    [SerializeField] int i = 0;
    [SerializeField] bool canClick = false;
    [SerializeField] GameObject advanceUI;
    [SerializeField] GameObject objToActivate;
    [SerializeField] bool hasObjToActivate;
    private int arrayLength;
    [SerializeField] private GameObject playerObj;

    [Header("Cutscene Video System")]
    [SerializeField] private VideoPlayer videoPlayer;
    //[SerializeField] private VideoClip[] videoClips;


    //[SerializeField] private

    //[Header("Audio")]

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
    private void Awake()
    {
        //var videoPlayer = gameObject.GetComponent<VideoPlayer>();
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
        arrayLength = cutsceneTimes.Length;
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
        videoPlayer.Play();
        //StartCoroutine(CutsceneOnDelay(0.75f));
        //cutsceneObjects[i].SetActive(true);
        //cutsceneObjects[i-1].SetActive(false);
        //StartCoroutine(CutsceneOffDelay(1));
        
            StartCoroutine(CutsceneCounter(cutsceneTimes[i]));
        
        
            
    }

    public void CutsceneNextVideo()
    {
        videoPlayer.Play();
    }

    IEnumerator CutsceneCounter(float time)
    {
        yield return new WaitForSeconds(time);
        videoPlayer.Pause();
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
        //cutsceneObjects[i].SetActive(false);
        i = 0;
        //cutsceneObjects[i].SetActive(true);
       
        
        
        
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
        //cutsceneObjects[i - 1].SetActive(false);
    }
    IEnumerator CutsceneOnDelay(float time)
    {
        yield return new WaitForSeconds(time);
        //cutsceneObjects[i].SetActive(true);
    }
}
