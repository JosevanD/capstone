using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSprites : MonoBehaviour
{
    [SerializeField] bool freezeXZAxis = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Billboard();
    }

    private void Billboard()
    {
        if (freezeXZAxis)
        {
            transform.rotation = Quaternion.Euler(0f, Camera.main.transform.rotation.eulerAngles.y, 0f);
        }

        else
        {
            transform.rotation = Camera.main.transform.rotation;
        }
    }
}
