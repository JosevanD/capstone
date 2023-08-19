using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MovingCamera : MonoBehaviour
{
   // public Transform targetPosition;
    public CinemachineVirtualCamera PlayerCam;
    public CinemachineVirtualCamera TargetCam;
    private float CamTimer;
    public float MaxCamTime;
    private bool isCollidePlayer;
    private void Start()
    {
        isCollidePlayer = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            isCollidePlayer = true;
            PlayerCam.Priority = 0;
            TargetCam.Priority = 1;

        }


    }

    private void Update()
    {
        if (isCollidePlayer == true)
        {
            CamTimer += Time.deltaTime;
            
        }
        if (CamTimer >= MaxCamTime)
        {
            PlayerCam.Priority = 1;
            TargetCam.Priority = 0;
            //Destroy(gameObject);

        }

    }
    /*private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            CurrCam.Priority = 0;
            TargetCam.Priority = 0;

        }


    }*/
}
