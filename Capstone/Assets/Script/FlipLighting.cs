using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipLighting : MonoBehaviour
{
    [SerializeField] private GameObject lightingObj1;
    [SerializeField] private GameObject lightingObj2;
    [SerializeField] int lightingNo = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            lightingObj2.SetActive(true);
            lightingObj1.SetActive(false);
        }
        


    }

    private void Wip()
    {
        if (lightingNo == 1)
        {
            lightingObj2.SetActive(true);
            lightingObj1.SetActive(false);
            lightingNo = 2;
        }

        if (lightingNo == 2)
        {
            lightingObj1.SetActive(true);
            lightingObj2.SetActive(false);
            lightingNo = 1;
        }
    }
}
