using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorPuzzle : MonoBehaviour
{
    private DoorPuzzleManager doorPuzzleManager;

    private void Awake()
    {
        doorPuzzleManager = FindObjectOfType<DoorPuzzleManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            doorPuzzleManager.DoorPuzzleCanvas.SetActive(true);

        }

    }
}
