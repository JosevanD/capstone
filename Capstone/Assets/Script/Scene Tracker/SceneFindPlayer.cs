using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFindPlayer : MonoBehaviour
{
    GameObject sceneTrackerObj;

    // Start is called before the first frame update
    void Start()
    {
        sceneTrackerObj = GameObject.Find("SceneTracker");
        sceneTrackerObj.GetComponent<SceneTracker>().FindPlayerPrefab();
        sceneTrackerObj.GetComponent<SceneTracker>().PlayerFound();
        Destroy(gameObject);
    }

    
}
