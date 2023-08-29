using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject popupUI;
    private bool isPopupActive;
 
    void Start()
    {
        isPopupActive = false;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player" && isPopupActive == false)
        {
            popupUI.SetActive(true);
            isPopupActive = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player" && isPopupActive == true)
        {
            popupUI.SetActive(false);
            isPopupActive = false;
        }
    }
    
}
