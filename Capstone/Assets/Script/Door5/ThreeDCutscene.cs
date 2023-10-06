using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeDCutscene : MonoBehaviour
{
    private float CurrWaitTime = 0f;
    public float WaitTimeForPlayerBack = 0f;
    public float WaitTimeForCouple = 0f;

    [Header("Player Back GameObj")]
    public GameObject PlayerBackObj;
    [Header("Couple Running Obj")]
    public GameObject CoupleRunningObj;
    public GameObject CoupleStandingObj;
    private bool isTrigger;
    // Start is called before the first frame update
    void Start()
    {
        isTrigger = false;
        CurrWaitTime = 0;
        PlayerBackObj.SetActive(false);
        CoupleRunningObj.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("triggered 3D Cutscene");
            isTrigger = true;
        }
    }
    private void Update()
    {
        if (isTrigger == true)
        {
            CurrWaitTime += Time.deltaTime;

        }
        if (CurrWaitTime >= WaitTimeForPlayerBack)
        {
            PlayerBackObj.SetActive(true);
        }
        if (CurrWaitTime >= WaitTimeForCouple)
        {
            CoupleRunningObj.SetActive(true);
            CoupleStandingObj.SetActive(false);

        }
    }
}
