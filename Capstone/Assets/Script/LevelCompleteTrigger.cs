using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject doorWhiteObj;

    void Start()
    {
        doorWhiteObj = GameObject.FindGameObjectWithTag("Magic Door");
        doorWhiteObj.GetComponent<DissolveScript>().DoorAppear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
