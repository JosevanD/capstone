using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandpaSprites : MonoBehaviour
{
    [Header("Animation Stuff")]

    [SerializeField] private string[] animPara = { "isWalkFront", "isWalkBack", "isWalkLeft", "isWalkRight" };
    [SerializeField] private Animator grandpaAnimator;


    private float oldPosX;
    private float oldPosZ;

    private float grandpaPosX;
    private float grandpaPosZ;

    [SerializeField] private bool isMovingFront;
    [SerializeField] private bool isMovingBack;
    [SerializeField] private bool isMovingLeft;
    [SerializeField] private bool isMovingRight;


    [SerializeField] private bool isNotMoving;

    [Header("Angle Stuff")]

    [SerializeField] private GameObject grandpaSystem;
    private Vector3 targetPos;
    [SerializeField] private float angle;
    //[SerializeField] private bool isFlipped;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        grandpaPosX = transform.position.x;
        grandpaPosZ = transform.position.z;

        CheckDirection();
        CheckAngle();
        NotMovingCheck();

        if (isNotMoving == false)
        {
            MoveLeft();
            MoveRight();
            MoveFront();
            MoveBack();
        }

        

    }

    private void LateUpdate()
    {
        oldPosX = grandpaPosX;
        oldPosZ = grandpaPosZ;
    }

    private void MoveFront()
    {
        if (isMovingFront == true)
        {
            grandpaAnimator.SetBool(animPara[0], true);
        }

        else
        {
            grandpaAnimator.SetBool(animPara[0], false);
        }
    }


    private void MoveBack()
    {
        if (isMovingBack == true)
        {
            grandpaAnimator.SetBool(animPara[1], true);
        }

        else
        {
            grandpaAnimator.SetBool(animPara[1], false);
        }
    }

    private void MoveLeft()
    {
        if (isMovingLeft == true)
        {
            grandpaAnimator.SetBool(animPara[2], true);
        }

        else
        {
            grandpaAnimator.SetBool(animPara[2], false);
        }
    }


    private void MoveRight()
    {
        if (isMovingRight == true)
        {
            grandpaAnimator.SetBool(animPara[3], true);
        }

        else
        {
            grandpaAnimator.SetBool(animPara[3], false);
        }
    }

    private void CheckAngle()
    {
        targetPos = GetComponent<GrandpaSystem>().GrandpaTargetPos();

        Vector3 targetDir = targetPos - transform.position;
        angle = Vector3.Angle(targetDir, transform.forward);


    }


    private void CheckDirection()
    {
        if (grandpaPosX < (oldPosX - 0.001) && (angle < 100 || angle > 50))
        {
            isMovingRight = true;

            isMovingLeft = false;
            isMovingFront = false;
            isMovingBack = false;
        }

        if (grandpaPosX > (oldPosX + 0.001) && (angle < 100 || angle > 50))
        {
            isMovingLeft = true;

            isMovingRight = false;
            isMovingFront = false;
            isMovingBack = false;
        }

        if (grandpaPosZ > (oldPosZ - 0.01) && (angle < 50 || angle > 100))
        {
            isMovingFront = true;

            isMovingBack = false;
            isMovingLeft = false;
            isMovingRight = false;
        }

        if (grandpaPosZ > (oldPosZ + 0.001) && (angle < 50 || angle > 100))
        {
            isMovingBack = true;

            isMovingFront = false;
            isMovingLeft = false;
            isMovingRight = false;
        }
        
        if (isNotMoving == true)
        {
            grandpaAnimator.Play("Anim_Grandpa_Empty");
            isMovingBack = false;
            isMovingFront = false;
            isMovingLeft = false;
            isMovingRight = false;
        }


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Grandpa Target")
        {

            isNotMoving = true;
            isMovingLeft = false;
            isMovingRight = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Grandpa Target")
        {

            isNotMoving = false;

        }



    }

    private void NotMovingCheck()
    {
        if ((grandpaPosZ - oldPosZ) < 0.0001 && (grandpaPosZ - oldPosZ) > -0.0001)
        {
            isNotMoving = true;
        }

        if ((grandpaPosX - oldPosX) < 0.0001 && (grandpaPosX - oldPosX) > -0.0001)
        {
            isNotMoving = true;
        }

        else
        {
            isNotMoving = false;
        }


    }

}
