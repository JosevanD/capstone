using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterName : MonoBehaviour
{

    [SerializeField] private GameObject objToActivate;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void OnDisable()
    {
        if (objToActivate != null)
        {
            objToActivate.SetActive(true);
            
        }
    }

    public void ChapterNameDisable()
    {
        gameObject.SetActive(false);
    }

}
