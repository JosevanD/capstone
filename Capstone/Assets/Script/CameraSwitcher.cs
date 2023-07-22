using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Player;
    public CinemachineVirtualCamera activeCam;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            activeCam.Priority = 1;

        
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            activeCam.Priority = 0;

        }


    }
}
