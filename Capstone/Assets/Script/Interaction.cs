using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public float InteractionDistance = 2;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, InteractionDistance);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.transform.tag == "Player")
                {
                    Debug.Log("Interected");
                    Destroy(gameObject);
                  
                }
            }
        
        }
    }
}
