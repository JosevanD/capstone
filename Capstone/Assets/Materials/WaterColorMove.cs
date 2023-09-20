using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterColorMove : MonoBehaviour
{
    [SerializeField] MeshRenderer mesh;

    private Material textureMaterial;

    private bool isMovingRight;

    private bool isMovingLeft;

    [SerializeField] float scrollAmount;

    [SerializeField] GameObject playerRB;

    [SerializeField] Rigidbody rb;

    private float scrollMagnitude;

    //positions X
    private float oldPosX;

    public float playerPosX;

    public bool wsPressed;

    [SerializeField] bool isFlipped;
    //public float posXDiff; 
    //positions Z


    private 
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
        
        playerPosX = playerRB.transform.position.x;

        //playerPosZ = playerRB.transform.position.z;

        scrollMagnitude = rb.velocity.magnitude;

        if (isFlipped == false)
        {
            PosCheck();
        }

        if (isFlipped == true)
        {
            PosCheckFlipped();
        }


        KeyCheck();

        if (isMovingRight == true && wsPressed == false)
        {
            textureMaterial.SetFloat("_Scroll_value", textureMaterial.GetFloat("_Scroll_value") - (scrollMagnitude * scrollAmount));
        }

        if (isMovingLeft == true && wsPressed == false)
        {
            textureMaterial.SetFloat("_Scroll_value", textureMaterial.GetFloat("_Scroll_value") + (scrollMagnitude * scrollAmount));
        }

        

    }

    void LateUpdate()
    {
        oldPosX = playerPosX;
    }

    private void KeyCheck()
    {

        if ((Input.GetKey(KeyCode.S) == true || Input.GetKey(KeyCode.W) == true) && (Input.GetKey(KeyCode.D) == false && Input.GetKey(KeyCode.A) == false))
        {
            wsPressed = true;
        }

        else
        {
            StartCoroutine(keyHold(0.51f));
            //wsPressed = false;
        }

    } 

    IEnumerator keyHold(float time)
    {
        yield return new WaitForSeconds(time);
        wsPressed = false;
    }

    private void PosCheck()
    {
        if (playerPosX > oldPosX)
        {
            isMovingRight = true;
            isMovingLeft = false;
        }

        if (playerPosX < oldPosX)
        {
            isMovingLeft = true;
            isMovingRight = false;
        }
    }

    private void PosCheckFlipped()
    {
        if (playerPosX < oldPosX)
        {
            isMovingRight = true;
            isMovingLeft = false;
        }

        if (playerPosX > oldPosX)
        {
            isMovingLeft = true;
            isMovingRight = false;
        }
    }

    public void FlipWaterColor()
    {
        isFlipped = true;
    }

}
