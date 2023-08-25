using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccomSprites : MonoBehaviour
{
    public bool freezeXZAxis = true;

    [Header("Animation Stuff")]

    [SerializeField] private string[] animPara = { "Flying Left", "Flying Right"};
    [SerializeField] private Animator accomAnimator;

    private float oldPosX;
    private float accomPosX;

    [SerializeField] private bool isMovingLeft;
    [SerializeField] private bool isMovingRight;

    [SerializeField] private bool isNotMoving;

    

    //public bool is side
    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
        accomPosX = transform.position.x;
        Billboard();
        CheckDirection();
        if (isNotMoving == false)
        {
            MoveLeft();
            MoveRight();
        }
        
    }

    void LateUpdate()
    {
        oldPosX = accomPosX;
    }

    private void Billboard()
    {
        if (freezeXZAxis)
        {
            transform.rotation = Quaternion.Euler(0f, Camera.main.transform.rotation.eulerAngles.y, 0f);
        }

        else
        {
            transform.rotation = Camera.main.transform.rotation;
        }
    }

    private void CheckDirection()
    {
        if (accomPosX > oldPosX)
        {
            isMovingRight = true;
            isMovingLeft = false;
        }

        if (accomPosX < oldPosX)
        {
            isMovingLeft = true;
            isMovingRight = false;
        }
    }


    private void MoveLeft()
    {
        if (isMovingLeft == true)
        {
            accomAnimator.SetBool(animPara[0], true);
        }

        else
        {
            accomAnimator.SetBool(animPara[0], false);
        }
    }


    private void MoveRight()
    {
        if (isMovingRight == true)
        {
            accomAnimator.SetBool(animPara[1], true);
        }

        else
        {
            accomAnimator.SetBool(animPara[1], false);
        }
    }
    
    

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Accom Target")
        {
            
            isNotMoving = true;
            isMovingLeft = false;
            isMovingRight = false;
        }

    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Accom Target")
        {
            
            isNotMoving = false;
            
        }

    }

}
