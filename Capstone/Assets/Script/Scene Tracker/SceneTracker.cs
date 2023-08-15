using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTracker : MonoBehaviour
{
    private static SceneTracker sceneTracker;

    public int exitDoorNo;
    public GameObject playerPrefab;
    public Vector3[] playerSpawnPos;
    public bool whiteHallway = false;
    public bool playerFound = false;

    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        if (sceneTracker == null)
        {
            sceneTracker = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        if (whiteHallway == true && playerFound == true)
        {
            playerPrefab.transform.position = playerSpawnPos[exitDoorNo];
            whiteHallway = false;
            playerFound = false;
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

    public void FindPlayerPrefab()
    {
        playerPrefab = GameObject.FindGameObjectWithTag("PlayerPrefab");
    }

    public void PlayerFound()
    {
        playerFound = true;
    }
}
