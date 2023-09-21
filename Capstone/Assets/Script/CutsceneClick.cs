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

    [Header("Audio")]

    [SerializeField] private GameObject bgAudioObject;

    [SerializeField] private int audioNo;

    [SerializeField] bool isChangeAudio;

    
    // Start is called before the first frame update
    void Start()
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
            cutsceneObjects[i].SetActive(false);
            i++;
            cutsceneObjects[i].SetActive(true);
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
            gameObject.SetActive(false);
        }
    }
}
