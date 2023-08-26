using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scratch2 : MonoBehaviour
{
    public GameObject maskPrefab;
    private bool isPressed = false;
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        var mousePos = Input.mousePosition;
        mousePos.z = 5;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        if (isPressed == true)
        {
            GameObject maskSprite = Instantiate(maskPrefab, mousePos, Quaternion.identity);
            maskSprite.transform.parent = gameObject.transform;

        }
        else 
        {
            
        
        }
        if (Input.GetMouseButton(0))
        {
            isPressed = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isPressed = false;
        }



    }
}
