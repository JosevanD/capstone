using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterName : MonoBehaviour
{

    [SerializeField] private GameObject objToActivate;
    [SerializeField] private Behaviour compToActivate;
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
            compToActivate.enabled = true;
        }
    }

}
