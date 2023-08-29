using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccomTarget : MonoBehaviour
{
    [Header("Attract Parameters")]
    [SerializeField] private bool isTarget;
    private GameObject accomCharaObject;
    private float accomDistance;
    [SerializeField] private float attractDistance; //minimum distance accom will be attracted
    [SerializeField] private float attractTime;
    private bool attractedCheck;
    [SerializeField] private GameObject attractTargetObj;

    // Start is called before the first frame update
    void Start()
    {
        if (attractTargetObj == null)
        {
            attractTargetObj = gameObject;
        }


        if (isTarget == true)
        {
            accomCharaObject = GameObject.FindGameObjectWithTag("Accom Chara");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isTarget == true)
        {
            CheckAccomDistance();
            AttractAccomChara();
        }
    }

    void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "Player" && isTarget == true)
        {
            ResetAttract();

        }
    }

    private void AttractAccomChara()
    {
        if (accomDistance <= attractDistance && attractedCheck == false)
        {
            StartCoroutine(StartAttract(attractTime));
        }
    }

    private void CheckAccomDistance()
    {
        accomDistance = Vector3.Distance(attractTargetObj.transform.position, accomCharaObject.transform.position);
    }

    IEnumerator StartAttract(float time)
    {
        attractedCheck = true;

        yield return new WaitForSeconds(time);


        if (accomDistance <= attractDistance)
        {
            accomCharaObject.GetComponent<AccomController>().SetTarget(attractTargetObj);
        }
    }

    private void ResetAttract()
    {
        accomCharaObject.GetComponent<AccomController>().ResetTarget();
        isTarget = false;
    }
}
