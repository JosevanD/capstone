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
    //public string currentSceneName;
    public string[] sceneNames = {"MenuScene","WhiteHallway", "Door1", "Door2", "Door3", "Door4", "Door5"};
    public bool sceneChanged;

    [Header("Audio Tracker")]
    public GameObject bgAudioController;

    [Header("Menu Stuff")]
    public GameObject pauseCanvas;

    [Header("Door Tracker")]
    public bool isDoor1Dissolved;
    public bool isDoor2Dissolved;
    public bool isDoor3Dissolved;
    public bool isDoor4Dissolved;
    public bool isDoor5Dissolved;

    [Header("Reward Tracker")]
    public int rewardsCollected;

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

    private void Start()
    {
        FindBGAudioController();
        //pauseMenu = GameObject.FindGameObjectWithTag("Pause Menu");
    }

    void Update()
    {
        
        //Teleports player in front of completed door & start door dissolve
        if (whiteHallway == true && playerFound == true)
        {
            CheckDoorDelete();
            playerPrefab.transform.position = playerSpawnPos[exitDoorNo];
            DoorDissolveActivate();
            
            DeleteLoading();
            whiteHallway = false;
            playerFound = false;
        }

        //Activate Magic door once level is completed

        if (levelCompleted == true && magicDoorAppeared == false)
        {
            ActivateMagicDoor();
        }

        //Pause Game
        //PauseMenu();

        if (sceneChanged == true)
        {
            ChangeMusic();
        }

        if (pauseCanvas == null)
        {
            pauseCanvas = GameObject.FindGameObjectWithTag("UI Canvas");
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

    public void FindBGAudioController()
    {
        bgAudioController = GameObject.FindGameObjectWithTag("BG Audio Controller");
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

    public void ChangeMusic()
    {
        Scene scene = SceneManager.GetActiveScene();

        //whitehallway
        if (scene.name == "WhiteHallway")
        {
            bgAudioController.GetComponent<BackgroundAudioController>().ChangeAudio(0);
            //pianotrack
        }

        //door1
        if (scene.name == "Door1")
        {
            bgAudioController.GetComponent<BackgroundAudioController>().ChangeAudio(3);
            //ambience
        }

        //door2
        if (scene.name == "Door2")
        {
            bgAudioController.GetComponent<BackgroundAudioController>().ChangeAudio(1);
            //ambience
        }

        //door3
        if (scene.name == "Door3")
        {
            bgAudioController.GetComponent<BackgroundAudioController>().ChangeAudio(2);
            //ambience
        }

        //door4
        if (scene.name == "Door4")
        {
            bgAudioController.GetComponent<BackgroundAudioController>().ChangeAudio(5);
            //ambience
        }

        //door5
        if (scene.name == "Door5")
        {
            bgAudioController.GetComponent<BackgroundAudioController>().ChangeAudio(2);
            //ambience
        }

        sceneChanged = false;
    }

    public void SceneChanged()
    {
        sceneChanged = true;
    }

    public void PauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseCanvas.GetComponent<PauseActivate>().Pause();
        }
    }

    public void CheckDoorDissolved(int doorNo)
    {
        if (doorNo == 1)
        {
            isDoor1Dissolved = true;
            doorNo = 0;
        }
        if (doorNo == 2)
        {
            isDoor2Dissolved = true;
            doorNo = 0;
        }
        if (doorNo == 3)
        {
            isDoor3Dissolved = true;
            doorNo = 0;
        }
        if (doorNo == 4)
        {
            isDoor4Dissolved = true;
            doorNo = 0;
        }
        if (doorNo == 5)
        {
            isDoor5Dissolved = true;
            doorNo = 0;
        }
    }

    private void DeleteLoading()
    {
        GameObject loadingScreen = GameObject.Find("LoadingScreen");
        if (loadingScreen != null) 
        {
            loadingScreen.SetActive(false);
        }
        
    }
    public void CheckDoorDelete()
    {
        GameObject door1ToDelete;
        GameObject door2ToDelete;
        GameObject door3ToDelete;
        GameObject door4ToDelete;
        GameObject door5ToDelete;

       
        if (isDoor1Dissolved == true)
        {
            door1ToDelete = GameObject.Find("Door 1");

            if (door1ToDelete != null)
            {
                door1ToDelete.SetActive(false);
            }

        }
        if (isDoor2Dissolved == true)
        {
            door2ToDelete = GameObject.Find("Door 2");

            if (door2ToDelete != null)
            {
                door2ToDelete.SetActive(false);
            }

        }

        
        if (isDoor3Dissolved == true)
        {
            door3ToDelete = GameObject.Find("Door 3");

            if (door3ToDelete != null)
            {
                door3ToDelete.SetActive(false);
            }
            
        }
        if (isDoor4Dissolved == true)
        {
            door4ToDelete = GameObject.Find("Door 4");

            if (door4ToDelete != null)
            {
                door4ToDelete.SetActive(false);
            }
        }
        if (isDoor5Dissolved == true)
        {
            door5ToDelete = GameObject.Find("Door 5");

            if (door5ToDelete != null)
            {
                door5ToDelete.SetActive(false);
            }
        }


    }
   
    public void RewardCollected()
    {
        rewardsCollected++;
    }


}
