using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccomController : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private GameObject targetObj;
    private GameObject originalTarget;
    private Vector3 targetObjPos;

    [Header("Settings")]

    [SerializeField] private float followSpeed = 0.003f;
    [SerializeField] private float followSpeedIncrease = 0.002f;

    private float originalSpeed;

    //[SerializeField] private bool isFollowing;

    [SerializeField] private float maxDistance;

    [Header("Audio")]
    [SerializeField] private AudioSource wingFlaps;
    [SerializeField] private float stationaryVolume;
    [SerializeField] private float movingVolume;
    [SerializeField] private float movingFastVolume;

    
    void Start()
    {
        originalTarget = targetObj;
        originalSpeed = followSpeed;
        wingFlaps.volume = stationaryVolume;
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
            wingFlaps.volume = movingFastVolume;
        }

        if (distance < maxDistance)
        {
            followSpeed = originalSpeed;
            wingFlaps.volume = movingVolume;
        }

        if (distance < 1)
        {
            wingFlaps.volume = stationaryVolume;
        }
    }

    private void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetObjPos, followSpeed);
    }
    
    public void SetTarget(GameObject newTarget)
    {
        targetObj = newTarget;

    }

    public void ResetTarget()
    {
        targetObj = originalTarget;
    }
}
