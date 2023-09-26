using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTrigger : MonoBehaviour
{

    [SerializeField] GameObject objToActivate;
    [SerializeField] GameObject objToDeActivate;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player" && objToActivate != null)
        {
            objToActivate.SetActive(true);
            gameObject.SetActive(false);
        }

        if (collider.tag == "Player" && objToDeActivate != null)
        {
            objToDeActivate.SetActive(false);
            gameObject.SetActive(false);
        }

       
    }

}
