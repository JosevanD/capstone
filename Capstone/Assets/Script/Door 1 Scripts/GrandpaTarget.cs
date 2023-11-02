using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandpaTarget : MonoBehaviour
{
    [SerializeField] private GameObject grandpaSystem;
    [SerializeField] private GameObject targetObj;
    
    [SerializeField] private float targetObjPosX;
    [SerializeField] private float targetObjPosZ;
    // Start is called before the first frame update
    void Start()
    {
        targetObjPosX = targetObj.transform.position.x;
        targetObjPosZ = targetObj.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            grandpaSystem.GetComponent<GrandpaSystem>().GrandpaTriggerFollow(targetObjPosX, targetObjPosZ);
        }
    }
}
