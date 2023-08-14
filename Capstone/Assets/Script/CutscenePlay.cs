using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutscenePlay : MonoBehaviour
{
    [Header("Cutscenes")]
    public GameObject cutsceneObject;
    public float cutsceneTime;

    [Header("Animation")]
    public Animator precutsceneAnim;
    public string animPara;
   
    [Header("Audio")]
    public AudioSource cutsceneAudio;
    public GameObject bgAudioObject;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            precutsceneAnim.SetBool(animPara, true);
        }
    }

    public void CutsceneOn()
    {
        bgAudioObject.GetComponent<BackgroundAudioController>().PauseBGAudio();
        cutsceneObject.SetActive(true);
        cutsceneAudio.enabled = true;
        StartCoroutine(CutsceneOff(cutsceneTime));
    }

    IEnumerator CutsceneOff(float time)
    {
        
        yield return new WaitForSeconds(time);

        cutsceneAudio.enabled = false;
        cutsceneObject.SetActive(false);
        bgAudioObject.GetComponent<BackgroundAudioController>().ResumeBGAudio();
    }
}
