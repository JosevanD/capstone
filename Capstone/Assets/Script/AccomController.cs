using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccomController : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private GameObject targetObj;
    private Vector3 targetObjPos;

    [Header("Settings")]

    [SerializeField] private float followSpeed = 0.003f;
    [SerializeField] private float followSpeedIncrease = 0.002f;

    private float originalSpeed;

    //[SerializeField] private bool isFollowing;

    [SerializeField] private float maxDistance;
    //public float accomVelocity;

    //private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        originalSpeed = followSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(targetObjPos, gameObject.transform.position);

        targetObjPos = targetObj.transform.position;

        //accomVelocity = rb.velocity.magnitude;
        //transform.position = Vector3.MoveTowards(transform.position, targetObjPos, followSpeed);
        if (distance >= maxDistance)
        {
            followSpeed = followSpeedIncrease;
        }

        if (distance < maxDistance)
        {
            followSpeed = originalSpeed;
        }
    }

    private void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetObjPos, followSpeed);
    }
    

}
