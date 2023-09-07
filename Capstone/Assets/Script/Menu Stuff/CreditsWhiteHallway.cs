using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsWhiteHallway : MonoBehaviour
{
    [SerializeField] private GameObject creditsObject;
    [SerializeField] private float creditsTime;
    private bool escToEscape = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (escToEscape == true && Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            creditsObject.SetActive(true);
            CreditsTimer(creditsTime);
            escToEscape = true;
        }
    }

    IEnumerator CreditsTimer(float time)
    {
        yield return new WaitForSeconds(time);
        Application.Quit();
    }
}
