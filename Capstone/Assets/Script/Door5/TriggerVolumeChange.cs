using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVolumeChange : MonoBehaviour
{
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("VolumeChange", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
