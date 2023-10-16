using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeDAnimation : MonoBehaviour
{

    [SerializeField] Animator threeDCutsceneAnimator;
    [SerializeField] GameObject player;
    //[SerializeField] Rigidbody rb;
    [SerializeField] Vector3 teleportTransform;
    [SerializeField] private GameObject bgAudioObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        threeDCutsceneAnimator.SetBool("CutsceneOn", true);
        bgAudioObject.GetComponent<BackgroundAudioController>().ChangeAudio(1);
    }

    public void PlayerTeleportDoorFive()
    {
        player.transform.localPosition = teleportTransform;
        
    }

    public void DisablePlayerThreeD()
    {
        player.SetActive(false);
    }

    public void EnablePlayerThreeD()
    {
        player.SetActive(true);
    }
}
