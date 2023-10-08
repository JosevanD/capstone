using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeDAnimation : MonoBehaviour
{

    [SerializeField] Animator threeDCutsceneAnimator;
    [SerializeField] GameObject player;
    [SerializeField] Vector3 teleportTransform;
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
    }

    public void PlayerTeleportDoorFive()
    {
        player.transform.position = teleportTransform;
    }
}
