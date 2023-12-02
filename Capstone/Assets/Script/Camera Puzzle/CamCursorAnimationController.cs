using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CamCursorAnimationController : MonoBehaviour
{
    private CameraPuzzleManager cameraPuzzleManager;
    private CamCursorCollision camCursorCollision;

    public GameObject CentralBoxObj;
    // Start is called before the first frame update
    void Start()
    {
        cameraPuzzleManager = FindObjectOfType<CameraPuzzleManager>();
        camCursorCollision = FindObjectOfType<CamCursorCollision>();
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
            //Debug.Log("I turn 0 on");
            cameraPuzzleManager.InnerBoxAnimator.SetBool("isHorizontal", true);
            //cameraPuzzleManager.InnerBoxAnimator.SetBool("isVertical", false);
        }
        if (RandomAnim == 1)
        {
            //Debug.Log("I turn 1 on");
            cameraPuzzleManager.InnerBoxAnimator.SetBool("isVertical", true);
            //cameraPuzzleManager.InnerBoxAnimator.SetBool("isHorizontal", false);

        }
        //Debug.Log(RandomAnim);

    }
    public void FinishedControl()
    {
        CentralBoxObj.SetActive(false);
        camCursorCollision.DoF.active = false;
    
    }

    }
