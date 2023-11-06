using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TriggerDoorPuzzle : MonoBehaviour
{
    private DoorPuzzleManager doorPuzzleManager;
    public GameObject DoorPuzzleCanvas;
    public GameObject OriginalDoorObj;

    public GameObject PlayerObj;

    [Header("Player Cameara")]
    public CinemachineVirtualCamera PlayerCam;
    [Header("the Behind Door Camera")]
    public CinemachineVirtualCamera TargetCam;

    private void Awake()
    {
        doorPuzzleManager = FindObjectOfType<DoorPuzzleManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            //doorPuzzleManager.DoorPuzzleCanvas.SetActive(true);
            DoorPuzzleCanvas.SetActive(true);
            //Switch Cam
            PlayerCam.Priority = 0;
            TargetCam.Priority = 1;

            PlayerObj.SetActive(false);
            OriginalDoorObj.SetActive(false);
            gameObject.SetActive(false);

        }

    }
}
