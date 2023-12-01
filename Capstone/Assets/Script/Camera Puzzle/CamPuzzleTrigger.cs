using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPuzzleTrigger : MonoBehaviour
{
    [Header("Cam Puzzle Canvas")]
    public GameObject CamPuzzleObj;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            CamPuzzleObj.SetActive(true);
        
        }
    }
}
