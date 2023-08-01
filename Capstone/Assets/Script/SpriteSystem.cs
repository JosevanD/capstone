using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSystem: MonoBehaviour
{
    [SerializeField] bool freezeXZAxis = true;

    [SerializeField] Animator spriteAnimator;

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
    }

}
