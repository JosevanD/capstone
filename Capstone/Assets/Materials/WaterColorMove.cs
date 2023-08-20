using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterColorMove : MonoBehaviour
{
    public MeshRenderer mesh;

    private Material textureMaterial;

    private bool isMovingRight;

    private bool isMovingLeft;

    public float scrollAmount;

    public GameObject playerRB;

    public Rigidbody rb;

    private float scrollMagnitude;

    private float oldPos;

    public float playerPos;
    // Start is called before the first frame update
    void Start()
    {
        if (mesh != null)
        {
            textureMaterial = mesh.material;
        }

        rb = playerRB.GetComponent<Rigidbody>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = playerRB.transform.position.x;

        scrollMagnitude = rb.velocity.magnitude;


        if (playerPos > oldPos)
        {
            isMovingRight = true;
            isMovingLeft = false;
        }

        if (playerPos < oldPos)
        {
            isMovingLeft = true;
            isMovingRight = false;
        }



        if (isMovingRight == true)
        {
            textureMaterial.SetFloat("_Scroll_value", textureMaterial.GetFloat("_Scroll_value") - (scrollMagnitude * scrollAmount));
        }

        if (isMovingLeft == true)
        {
            textureMaterial.SetFloat("_Scroll_value", textureMaterial.GetFloat("_Scroll_value") + (scrollMagnitude * scrollAmount));
        }



    }

    void LateUpdate()
    {
        oldPos = playerPos;
    }
}
