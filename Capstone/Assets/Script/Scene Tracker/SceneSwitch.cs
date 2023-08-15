using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitch : MonoBehaviour
{
    public string TargetSceneName;
    public int currentDoorNumber;
    public GameObject sceneTrackerObj;
    public bool fromWhiteHallway;

    private void Start()
    {
        sceneTrackerObj = GameObject.Find("SceneTracker");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && fromWhiteHallway == false)
        {
            sceneTrackerObj.GetComponent<SceneTracker>().InWhiteHallway();

            sceneTrackerObj.GetComponent<SceneTracker>().FromSceneNo(currentDoorNumber);

            
            SceneManager.LoadScene(TargetSceneName);
        }

        if (other.transform.tag == "Player" && fromWhiteHallway == true)
        {
            
            SceneManager.LoadScene(TargetSceneName);

        }

    }
}
