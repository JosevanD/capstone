using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Charactor_Controller : MonoBehaviour
{
    [Header("Player Status")]
    public bool isInteracting;

    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float airMultiplier;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    [Header("Audio")]
    public AudioSource FootStepAudioSource;
    public AudioClip FootStepClip;
    public float StopAudioAfter = 0.5f;


    [Header("Animation")]
    public Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        isInteracting = false;

        

        FootStepAudioSource = GetComponent<AudioSource>();
        FootStepAudioSource.clip = FootStepClip;
        FootStepAudioSource.enabled = false;
    }

    private void Update()
    {
        grounded = true;
        //Debug.Log(grounded);
        MyInput();
        SpeedControl();

        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;


        if (horizontalInput != 0 || verticalInput != 0)
        { 
            FootStepAudioSource.enabled = true; 
        }
        if (horizontalInput == 0 && verticalInput == 0)
        {
            
            FootStepAudioSource.enabled = false;
            //FootStepAudioSource.PlayOneShot(FootStepClip);
            //StartCoroutine(StopAudio(StopAudioAfter));
        }

    }

    private void FixedUpdate()
    {
        if(isInteracting != true)
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        /*if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }*/
    }

    private void MovePlayer()
    {
        
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // in air
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    

    IEnumerator StopAudio(float time)
    {
        yield return new WaitForSeconds(time);
        //FootStepAudioSource.Stop();
        FootStepAudioSource.enabled = false;
    }
}
