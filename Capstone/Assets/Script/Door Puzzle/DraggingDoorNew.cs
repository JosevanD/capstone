using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggingDoorNew : MonoBehaviour
{
    public float ySensitivity = 300f;
    public float frontOpenPosLimit = 45;
    public float backOpenPosLimit = 45;

    public GameObject frontDoorCollider;
    public GameObject backDoorCollider;

    bool moveDoor = false;
    DoorCollision doorCollision = DoorCollision.NONE;

    private DoorPuzzleManager doorPuzzleManager;

    SceneSwitch sceneSwitch;

    private bool isClosingPlay;


    // Use this for initialization
    private void Awake()
    {
        doorPuzzleManager = FindObjectOfType<DoorPuzzleManager>();
        sceneSwitch = FindObjectOfType<SceneSwitch>();
    }
    void Start()
    {
        StartCoroutine(doorMover());
        isClosingPlay = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            moveDoor = true;
            Debug.Log("Front door hit");
            doorCollision = DoorCollision.BACK;
            //moveDoor = true;
            Debug.Log("Mouse down");

           
        }

        if (Input.GetMouseButtonUp(0))
        {
            moveDoor = false;
            Debug.Log("Mouse up");
        }
    }

    IEnumerator doorMover()
    {
        bool stoppedBefore = false;
        float yRot = 90;

        while (true)
        {
            if (moveDoor)
            {
                stoppedBefore = false;
                Debug.Log("Moving Door");

                yRot += Input.GetAxis("Mouse Y") * ySensitivity * Time.deltaTime;


                //Check if this is front door or back
                if (doorCollision == DoorCollision.FRONT)
                {
                    Debug.Log("Pull Down(PULL TOWARDS)");
                    yRot = Mathf.Clamp(yRot, -frontOpenPosLimit, 0);
                    Debug.Log(yRot);
                    transform.localEulerAngles = new Vector3(0, -yRot, 0);
                }
                else if (doorCollision == DoorCollision.BACK)
                {
                    Debug.Log("Pull Up(PUSH AWAY)");
                    yRot = Mathf.Clamp(yRot, 0, backOpenPosLimit);
                    Debug.Log(yRot);
                    transform.localEulerAngles = new Vector3(0, yRot, 0);
                }
            }
            if (yRot <= 0)
            {
                
                yRot = 0;
                moveDoor = false;
                if (!isClosingPlay)
                {
                    doorPuzzleManager.DoorAudioSource.PlayOneShot(doorPuzzleManager.ClosingClip);
                    isClosingPlay = true;
                }
                
                StartCoroutine(Countdown(3));

            }
            else
            {
                if (!stoppedBefore)
                {
                    stoppedBefore = true;
                    Debug.Log("Stopped Moving Door");
                }
            }

            yield return null;
        }

    }

    IEnumerator Countdown(int seconds)
    {
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }
        
        Debug.Log("complete");
        sceneSwitch.TriggerSceneSwitch();
        doorPuzzleManager.DoorPuzzleCanvas.SetActive(false);


    }


    enum DoorCollision
    {
        NONE, FRONT, BACK
    }
}
