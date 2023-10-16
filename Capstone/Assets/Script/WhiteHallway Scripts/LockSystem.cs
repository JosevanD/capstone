using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockSystem : MonoBehaviour
{

    [SerializeField] private GameObject unlockObj; //object that will unlock door if pressed E
    [SerializeField] private GameObject prevDoorUnlock; //popup ui of previous door

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
        unlockObj.SetActive(true);
        if (prevDoorUnlock != null)
        {
            prevDoorUnlock.SetActive(false);
        }
        
    }
}
