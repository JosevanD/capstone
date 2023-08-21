using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject doorWhiteObj;

    void Start()
    {
        //doorWhiteObj = GameObject.FindGameObjectWithTag("Magic Door");
        //doorWhiteObj.GetComponent<DissolveScript>().DoorAppear();
        doorWhiteObj.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
