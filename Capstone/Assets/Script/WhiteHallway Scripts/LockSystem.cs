using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject unlockObj; //object that will unlock door if pressed E

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

    }
}
