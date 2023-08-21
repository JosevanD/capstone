using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccomController : MonoBehaviour
{
    public GameObject targetObj;
    private Vector3 targetObjPos;
    public float followSpeed = 0.003f;
    private bool isFollowing;
    //public float accomVelocity;

    //private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        targetObjPos = targetObj.transform.position;

        //accomVelocity = rb.velocity.magnitude;
        //transform.position = Vector3.MoveTowards(transform.position, targetObjPos, followSpeed);
    }

    private void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetObjPos, followSpeed);
    }
    

}
