using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutscenePlay : MonoBehaviour
{
    [Header("Cutscenes")]
    public GameObject cutsceneObject;
    public float cutsceneTime;
    public bool cutscenePlayOnce = true;
    

    [Header("Animation")]
    public Animator precutsceneAnim;
    public string animPara;
    public bool hasAnimation;
   
    [Header("Audio")]
    public AudioSource cutsceneAudio;
    public GameObject bgAudioObject;

    [Header("Misc")]
    public GameObject objToActivate;
    public GameObject objToDeactivate;
    public bool hasObjToActivate = false;
    public bool hasObjToDectivate = false;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player" && hasAnimation == true)
        {
            precutsceneAnim.SetBool(animPara, true);   
        }

        if (collider.tag == "Player" && hasAnimation == false)
        {
            
            CutsceneOn();
        }

    }

    public void CutsceneOn()
    {
        //pauses BG Music, sets cutscene on and cutscene audio on
        bgAudioObject.GetComponent<BackgroundAudioController>().PauseBGAudio();
        cutsceneObject.SetActive(true);
        cutsceneAudio.enabled = true;

        //starts timer for cutscene music and off
        StartCoroutine(CutsceneOff(cutsceneTime));
    }

    IEnumerator CutsceneOff(float time)
    {
        //wait for seconds
        yield return new WaitForSeconds(time);

        //disable audio, cutscene and resume BG Audio
        cutsceneAudio.enabled = false;
        cutsceneObject.SetActive(false);
        bgAudioObject.GetComponent<BackgroundAudioController>().ResumeBGAudio();

        //deactivates an object
        if (hasObjToDectivate == true)
        {
            objToDeactivate.SetActive(false);
        }


        //activate any objects
        if (hasObjToActivate == true)
        {
            objToActivate.SetActive(true);
        }
        

        if (cutscenePlayOnce == true)
        {
            Destroy(gameObject);
        }
    }
}
