using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMenu : MonoBehaviour
{
    public GameObject menuObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoBackToMenu()
    {
        gameObject.SetActive(false);
        menuObject.SetActive(true);
    }

    void DeActiveateMenu()
    {
        menuObject.SetActive(false);
    }

}
