using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPuzzleTrigger : MonoBehaviour
{
    [Header("Cam Puzzle Canvas")]
    public GameObject CamPuzzleObj;
    //public GameObject PlayerObj;
    private bool isCollided = false;
    //private Charactor_Controller charactor_Controller;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" )
        {
            isCollided = true;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isCollided)
        {
            CamPuzzleObj.SetActive(true);
            //PlayerObj.SetActive(false);
        }

    }
}
