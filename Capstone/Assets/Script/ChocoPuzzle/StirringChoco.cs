using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StirringChoco : MonoBehaviour
{
    public GameObject objectToDrag;

    private float startTime = 0f;
    private float pressTime = 0f;

    public float totalPressTime = 0f;

    public void OnMouseDrag()
    {
        
        objectToDrag.transform.position = Input.mousePosition;
        pressTime += Time.deltaTime;


    }
    public void OnMouseUp()
    {
        //pressTime = Time.time - pressTime;
       
        Debug.Log("press Time is " + pressTime);
        pressTime = 0;
    }

    void Update()
    {
        //Debug.Log("1");

        if (pressTime >= totalPressTime)
        {
            Debug.Log("puzzle complete! ");
        }
    }
}
