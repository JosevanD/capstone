using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDissolve : MonoBehaviour
{
    public GameObject sceneTrackerObj;
    public GameObject doorToDissolve;
    public int doorNumber;
    private string[] doorNames;
    //public GameObject doorToAppear;
    public bool isDissolved;

    // Start is called before the first frame update

    void Awake()
    {
        sceneTrackerObj = GameObject.Find("SceneTracker");

        doorNames = new string[] { "Door 0", "Door 1", "Door 2", "Door 3", "Door 4", "Door 5" };

        doorNumber = sceneTrackerObj.GetComponent<SceneTracker>().SetDissolveDoorNumber();

        FindDoor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FindDoor()
    {
        doorToDissolve = GameObject.Find(doorNames[doorNumber]);
    }

    public void CallDissolve()
    {
        doorToDissolve.GetComponent<DissolveScript>().DoorDissolve();
        

        StartCoroutine(CallDissolveDelay(2.1f));
    }

    IEnumerator CallDissolveDelay(float i)
    {
        yield return new WaitForSeconds(i);

        doorToDissolve.GetComponent<DissolveScript>().DoorDissolve();
    }
}
