using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPuzzleManager : MonoBehaviour
{
    [Header("Door Puzzle Canvas")]
    public GameObject DoorPuzzleCanvas;

    [Header("Door Puzzle Instruction")]
    public GameObject DoorPuzzleInstructionObj;

    [HideInInspector]
    public AudioSource DoorAudioSource;

    [Header("Door SFX")]
    public AudioClip ClosingClip;

    [HideInInspector]
    public SceneSwitch sceneSwitch;
    // Start is called before the first frame update
    void Awake()
    {
        //DoorPuzzleCanvas.SetActive(false);
        DoorAudioSource = GetComponent<AudioSource>();
        sceneSwitch = FindObjectOfType<SceneSwitch>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Player")
        {
            DoorPuzzleCanvas.SetActive(true);
            DoorPuzzleInstructionObj.SetActive(true);
        }

    }


}
