using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCursorAnimationController : MonoBehaviour
{
    private CameraPuzzleManager cameraPuzzleManager;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraPuzzleManager = FindObjectOfType<CameraPuzzleManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RandomAnimation()
    {
        cameraPuzzleManager.InnerBoxAnimator.SetBool("isHorizontal", false);
        cameraPuzzleManager.InnerBoxAnimator.SetBool("isVertical", false);
        
    }
    public void IdleControl()
    {
        var RandomAnim = Random.Range(0, 2);
        if (RandomAnim == 0)
        {
            Debug.Log("I turn 0 on");
            cameraPuzzleManager.InnerBoxAnimator.SetBool("isHorizontal", true);
            //cameraPuzzleManager.InnerBoxAnimator.SetBool("isVertical", false);
        }
        if (RandomAnim == 1)
        {
            Debug.Log("I turn 1 on");
            cameraPuzzleManager.InnerBoxAnimator.SetBool("isVertical", true);
            //cameraPuzzleManager.InnerBoxAnimator.SetBool("isHorizontal", false);

        }
        Debug.Log(RandomAnim);

    }
    }
