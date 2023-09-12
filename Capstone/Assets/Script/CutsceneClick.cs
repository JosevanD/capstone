using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneClick : MonoBehaviour
{
    [SerializeField] GameObject[] cutsceneObjects;
    [SerializeField] float[] cutsceneTimes;
    [SerializeField] int i = 0;
    [SerializeField] bool canClick = false;
    [SerializeField] GameObject advanceUI;
    [SerializeField] GameObject objToActivate;
    [SerializeField] bool hasObjToActivate;
    private int arrayLength;
    // Start is called before the first frame update
    void Start()
    {
        arrayLength = cutsceneObjects.Length;
        StartCoroutine(CutsceneCounter(cutsceneTimes[i]));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canClick == true && i < (arrayLength - 1))
        {
            CutsceneClickAdv();
            canClick = false;
        }

        
    }

    public void CutsceneClickAdv()
    {
            advanceUI.SetActive(false);
            cutsceneObjects[i].SetActive(false);
            i++;
            cutsceneObjects[i].SetActive(true);
            StartCoroutine(CutsceneCounter(cutsceneTimes[i]));
            
    }

    IEnumerator CutsceneCounter(float time)
    {
        yield return new WaitForSeconds(time);
        canClick = true;
        advanceUI.SetActive(true);

        if (i == (arrayLength - 1))
        {
            if (hasObjToActivate == true)
            {
                objToActivate.SetActive(true);
            }
            advanceUI.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
