using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SpriteSystem : MonoBehaviour
{
    [SerializeField] bool freezeXZAxis = true;

    [SerializeField] Animator spriteAnimator;

    [SerializeField] GameObject walkAudioObject;

    private bool isWalkRight;
    private bool isWalkLeft;
    //bool isWalking = false;
    //bool audioToggle = true;
    private float leftA;
    private float backW;
    private float forwardS;
    private float rightA;
    
    private float horizontalInput;
    private float verticalInput;
    void Update()
    {
        MyInput();

        Billboard();

        SpriteAnim();
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

    private void SpriteAnim()
    {
        if (verticalInput == -1)
        {
            spriteAnimator.SetBool("FrontWalk", true);
        }

        else
        {
            spriteAnimator.SetBool("FrontWalk", false);
        }

        if (horizontalInput == 1)
        {
            spriteAnimator.SetBool("RightWalk", true);
            isWalkRight = true;
        }

        else
        {
            spriteAnimator.SetBool("RightWalk", false);
            isWalkRight = false;
        }

        if (horizontalInput == -1)
        {
            spriteAnimator.SetBool("LeftWalk", true);
            isWalkLeft = true;
        }

        else
        {
            spriteAnimator.SetBool("LeftWalk", false);
            isWalkLeft = false;
        }

        if (verticalInput == 1)
        {
            spriteAnimator.SetBool("BackWalk", true);
        }

        else
        {
            spriteAnimator.SetBool("BackWalk", false);
        }
    }


    private void Walking()
    {
        if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D)))
        {
            //isWalking = true;
            walkAudioObject.SetActive(true);

        }
        else
        {
            //walkAudio.SetActive = false;
            walkAudioObject.SetActive(false);
        }
     
    }

    public bool IsWalkRight()
    {
        if (isWalkRight == true)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
    public bool IsWalkLeft()
    {
        if (isWalkLeft == true)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
}
