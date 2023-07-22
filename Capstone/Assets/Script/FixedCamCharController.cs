using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedCamCharController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float turnSpeed;
    private CharacterController controller;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir;

        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);
        moveDir = transform.forward * Input.GetAxis("Vertical") * speed;
        // moves the character in horizontal direction
        controller.Move(moveDir * Time.deltaTime - Vector3.up * 0.1f);
    }
}
