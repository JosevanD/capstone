using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCursorMovement : MonoBehaviour
{
    public float RandomMovementRange;
    public float speed;
    private Vector3 InitPos;
    // Update is called once per frame

    private void Start()
    {
        InitPos = gameObject.transform.position;
    }
    void Update()
    {
        var Step = speed * Time.deltaTime;
        Vector2 randomPos = new Vector3(Random.Range(-RandomMovementRange, RandomMovementRange), Random.Range(-RandomMovementRange, RandomMovementRange), InitPos.z);
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, randomPos, Step);

    }
}
