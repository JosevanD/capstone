using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandpaSystem : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private GameObject targetObj;
    [SerializeField] private Vector3 targetObjPos;
    //private GameObject originalTarget;
    //private Vector3 targetObjPos;
    private float startingY;
    private bool following;
    [Header("Settings")]

    [SerializeField] private float followSpeed = 0.003f;


    void Start()
    {
        startingY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(targetObjPos, gameObject.transform.position);

        if (distance < 0.5 && following == true)
        {
            GrandpaFollowOff();
        }
    }

    private void LateUpdate()
    {
        //transform.position.y = startingY;
        if (following == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetObjPos, followSpeed);
        }

        
    }
    public void GrandpaTriggerFollow(float x, float z)
    {
        //transform.position = Vector3.MoveTowards(transform.position, targetObjPos, followSpeed);
        targetObjPos = new Vector3 (x, startingY, z);
        following = true;
    }

    private void GrandpaFollowOff()
    {
        following = false;
    }

    public Vector3 GrandpaTargetPos()
    {
        Vector3 pos = targetObjPos;
        return pos;
    }
}
