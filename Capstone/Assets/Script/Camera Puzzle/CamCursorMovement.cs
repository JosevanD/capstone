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
    
    private Vector3 InitPos;
    private bool isCoolDown;
    // Update is called once per frame

    private void Start()
    {
        InitPos = gameObject.transform.position;
        RandomPosition = InitPos;
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
        //gameObject.transform.position = Vector3.Lerp(transform.position, RandomPosition, Step);
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, RandomPosition, Step);
        //transform.position = new Vector3(Mathf.PingPong(Time.time * 1.5f, 6) - 3, Mathf.PingPong(Time.time * 1.5f, 6) - 3, InitPos.z);
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
        Vector3 randomPos = new Vector3(Random.insideUnitSphere.x * RandomMovementRange, Random.insideUnitSphere.y * RandomMovementRange, InitPos.z);
        RandomPosition = randomPos;
        isCoolDown = true;
    }
}
