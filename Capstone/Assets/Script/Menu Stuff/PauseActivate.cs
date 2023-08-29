using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseActivate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject pauseMenu;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);

    }
}
