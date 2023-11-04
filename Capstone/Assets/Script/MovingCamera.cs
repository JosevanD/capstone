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

    [SerializeField] bool usingTrigger = true;
    [SerializeField] bool isRepeatable = false;
    [Header ("Activate Objects")]
    [SerializeField] GameObject objToActivate;
    [SerializeField] bool hasObjToActivate;
    private bool objActivated;
    private void Start()
    {
        isCollidePlayer = false;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && usingTrigger == true)
        {
            isCollidePlayer = true;
            PlayerCam.Priority = 0;
            TargetCam.Priority = 1;

            if (hasObjToActivate == true && objActivated == false)
            {
                StartCoroutine(StartObject(MaxCamTime));
            }
            
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
            if (isRepeatable == true)
            {
                CamTimer = 0;
            }
        }

    }

    IEnumerator StartObject(float time)
    {
        objActivated = true;
        yield return new WaitForSeconds(time);
        objToActivate.SetActive(true);
    }

    public void CameraMove()
    {
        isCollidePlayer = true;
        PlayerCam.Priority = 0;
        TargetCam.Priority = 1;

        if (hasObjToActivate == true && objActivated == false)
        {
            StartCoroutine(StartObject(MaxCamTime));
        }

    }
}
