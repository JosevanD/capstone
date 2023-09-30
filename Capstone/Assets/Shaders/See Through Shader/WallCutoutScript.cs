using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCutoutScript : MonoBehaviour
{
    [SerializeField] private GameObject[] Wall;
    [SerializeField] private GameObject[] BehindWall;
    [SerializeField] private Material WallCutOutShader;
    [SerializeField] private Material NormalMaterial;
    [SerializeField] private GameObject Player;
    [SerializeField] private bool isBehindWall = false;


    // Start is called before the first frame update
    void Start()
    {

        //isBehindWall = false;


        for (int i = 0; i < Wall.Length; i++)
        {
            Wall[i].GetComponentInChildren<MeshRenderer>().material = NormalMaterial;
        }

    }
    void Update()
    {
        if (isBehindWall == true)
        {
            if (Player.tag == "Player")
            {
                //Debug.Log("I am standing behind the wall");
                for (int i = 0; i < Wall.Length; i++)
                {
                    Wall[i].GetComponentInChildren<MeshRenderer>().material = WallCutOutShader;
                }
;

            }

        }
        else if (isBehindWall == false)
        {
            //Debug.Log("I am NOT standing behind wall");
            for (int i = 0; i < Wall.Length; i++)
            {
                Wall[i].GetComponentInChildren<MeshRenderer>().material = NormalMaterial;
            }
        }
    }

    void OnTriggerStay(Collider Player)
    {
        if (Player.tag == "Player")
        {
            isBehindWall = true;
        }


    }

    void OnTriggerExit(Collider Player)
    {
        isBehindWall = false;
    }
}