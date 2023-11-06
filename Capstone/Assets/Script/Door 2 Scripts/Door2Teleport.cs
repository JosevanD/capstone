using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2Teleport : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject teleportObj;
    [SerializeField] bool inTrigger;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    

    private void Update()
    {


    }


    public void PlayerTeleportDoor2()
    {
        player.transform.position = teleportObj.transform.position;
    }

}
