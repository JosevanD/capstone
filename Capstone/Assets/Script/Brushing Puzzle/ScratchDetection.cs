using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchDetection : MonoBehaviour
{
    private Scratch2 scratch2;
    // Start is called before the first frame update
    void Start()
    {
        scratch2 = FindObjectOfType<Scratch2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseExit()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("Touched");
            scratch2.DetectionCount += 1;
            gameObject.GetComponent<Collider2D>().enabled = false;
        
        }
    }
}
