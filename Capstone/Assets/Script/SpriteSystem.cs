using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SpriteSystem : MonoBehaviour
{
    [SerializeField] bool freezeXZAxis = true;

    [SerializeField] Animator spriteAnimator;

    [SerializeField] GameObject walkAudioObject;

    //bool isWalking = false;
    //bool audioToggle = true;

    void Update()
    {

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
        if (Input.GetKey(KeyCode.S))
        {
            spriteAnimator.SetBool("FrontWalk", true);
        }

        else
        {
            spriteAnimator.SetBool("FrontWalk", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            spriteAnimator.SetBool("RightWalk", true);
        }

        else
        {
            spriteAnimator.SetBool("RightWalk", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            spriteAnimator.SetBool("LeftWalk", true);
        }

        else
        {
            spriteAnimator.SetBool("LeftWalk", false);
        }

        if (Input.GetKey(KeyCode.W))
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
}
