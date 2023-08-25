using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangedCheck : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject sceneTracker;
    [SerializeField] private bool scenedChanged = false;
    void Start()
    {
        scenedChanged = true;
        sceneTracker = GameObject.Find("SceneTracker");
        sceneTracker.GetComponent<SceneTracker>().SceneChanged();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
