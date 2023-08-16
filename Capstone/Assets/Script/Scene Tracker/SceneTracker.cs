using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTracker : MonoBehaviour
{
    private static SceneTracker sceneTracker;

    [Header("Player Tracker")]
    public int exitDoorNo;
    public GameObject playerPrefab;
    public Vector3[] playerSpawnPos;
    public bool whiteHallway = false;
    public bool playerFound = false;

    [Header("Level Tracker")]
    public bool levelCompleted = false;
    public bool magicDoorAppeared = false;
    public GameObject magicDoorPrefab;
    public GameObject triggerDissolveObj;


    // Start is called before the first frame update
    private void Awake()
    {
        //ensuring script object is not destroyed through changing scenes
        DontDestroyOnLoad(transform.gameObject);

        //ensuring no duplicates
        if (sceneTracker == null)
        {
            sceneTracker = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    

    void Update()
    {
        //Teleports player in front of completed door & start door dissolve
        if (whiteHallway == true && playerFound == true)
        {
            playerPrefab.transform.position = playerSpawnPos[exitDoorNo];
            DoorDissolveActivate();
            whiteHallway = false;
            playerFound = false;
        }

        //Activate Magic door once level is completed

        if (levelCompleted == true && magicDoorAppeared == false)
        {
            ActivateMagicDoor();
        }

        //Quit Game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
    public void InWhiteHallway()
    {
        whiteHallway = true;
    }

    public void FromSceneNo(int sNumber)
    {
        exitDoorNo = sNumber;
    }

    public int SetDissolveDoorNumber()
    {
        int doorNumber;
        doorNumber = exitDoorNo;
        return doorNumber;
    }

    public void FindPlayerPrefab()
    {
        playerPrefab = GameObject.FindGameObjectWithTag("PlayerPrefab");
    }

    public void PlayerFound()
    {
        playerFound = true;
    }


    //Level Complete Code
    public void LevelCompleted()
    {
        levelCompleted = true;
    }

    public void FindMagicDoor()
    {
        magicDoorPrefab = GameObject.FindGameObjectWithTag("Magic Door");
    }

    public void ActivateMagicDoor()
    {
        //magicDoorPrefab.SetActive(true);
        magicDoorPrefab.GetComponent<DissolveScript>().DoorAppear();
        magicDoorAppeared = true;
        levelCompleted = false;
    }

    //Trigger Door Dissolve
    public void DoorDissolveActivate()
    {
        triggerDissolveObj = GameObject.Find("TriggerDissolve");
        triggerDissolveObj.GetComponent<TriggerDissolve>().CallDissolve();
    }
}
