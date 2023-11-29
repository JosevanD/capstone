using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCursorMovement : MonoBehaviour
{
    [Range(0,4)]
    public float RandomMovementRange;
    public float speed;
    [HideInInspector]
    public Vector3 RandomPosition;

    [Header("Central Position")]
    public GameObject CentralBoxObj;
    private Vector3 CentralPos;

    private bool isCoolDown;

    private void Start()
    {

        CentralPos = new Vector3(CentralBoxObj.transform.position.x, CentralBoxObj.transform.position.y, gameObject.transform.position.z);
        RandomPosition = CentralPos;

        Vector3 randomPos = new Vector3(CentralPos.x + Random.insideUnitSphere.x * RandomMovementRange, CentralPos.y + Random.insideUnitSphere.y * RandomMovementRange, CentralPos.z);
        gameObject.transform.position = randomPos;
        isCoolDown = true;
    }
    void Update()
    {
        var Step = speed * Time.deltaTime;
        //Vector3 randomPos = new Vector3(Random.Range(-RandomMovementRange, RandomMovementRange), Random.Range(-RandomMovementRange, RandomMovementRange), InitPos.z);
       

        if (isCoolDown)
        {
            StartCoroutine(Countdown(2));
            isCoolDown = false;
        
        }
        
        if (!isCoolDown)
        {
            //gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, RandomPosition, Step);
            gameObject.transform.position = Vector3.Lerp(transform.position, RandomPosition, Step);
            //transform.position = new Vector3(Mathf.PingPong(Time.time * 1.5f, 6) - 3, Mathf.PingPong(Time.time * 1.5f, 6) - 3, InitPos.z);
        }

    }

    IEnumerator Countdown(int seconds)
    {
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }

        //Vector3 randomPos = new Vector3(InitPos.x + Random.Range(-RandomMovementRange, RandomMovementRange), InitPos.y + Random.Range(-RandomMovementRange, RandomMovementRange), InitPos.z);
        Vector3 randomPos = new Vector3(CentralPos.x + Random.insideUnitSphere.x * RandomMovementRange, CentralPos.y + Random.insideUnitSphere.y * RandomMovementRange, CentralPos.z);
        RandomPosition = randomPos;
        isCoolDown = true;
    }
}
