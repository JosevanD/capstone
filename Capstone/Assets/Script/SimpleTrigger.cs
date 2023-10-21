using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTrigger : MonoBehaviour
{

    [SerializeField] GameObject objToActivate;
    [SerializeField] GameObject objToDeActivate;
    [SerializeField] bool hasDeactivateDelay;
    [SerializeField] float delay;
    private BoxCollider bCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        bCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player" && objToActivate != null && hasDeactivateDelay == false)
        {
            objToActivate.SetActive(true);
            //gameObject.SetActive(false);
            bCollider.enabled = false;
        }

        if (collider.tag == "Player" && objToDeActivate != null && hasDeactivateDelay == false)
        {
            objToDeActivate.SetActive(false);
            //gameObject.SetActive(false);
            bCollider.enabled = false;
        }

        if (collider.tag == "Player" && objToDeActivate != null && hasDeactivateDelay == true)
        {
            delayDeactivate(delay);
            //gameObject.SetActive(false);
            bCollider.enabled = false;
        }

        
    }

    IEnumerator delayDeactivate(float time)
    {
        yield return new WaitForSeconds(time);
        objToDeActivate.SetActive(false);
        //gameObject.SetActive(false);
        //bCollider.enabled = false;

    }

}
