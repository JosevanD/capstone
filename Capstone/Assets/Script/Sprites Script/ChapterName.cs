using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterName : MonoBehaviour
{

    [SerializeField] GameObject objToActivate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChapterActivateObject()
    {
        if (objToActivate != null)
        {
            objToActivate.SetActive(true);
        }
        
    }

    
}
