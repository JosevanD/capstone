using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    [SerializeField] GameObject menuObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoBackToMenu()
    {
        gameObject.SetActive(false);
        menuObject.SetActive(true);
    }

    void DeActiveateMenu()
    {
        menuObject.SetActive(false);
    }

    public void BackToMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
