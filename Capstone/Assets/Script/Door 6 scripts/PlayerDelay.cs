using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDelay : MonoBehaviour
{
    [SerializeField] float delayTime;
    [SerializeField] private GameObject playerObj;
    [SerializeField] private GameObject standingSpriteObj;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayPlayerAppear(delayTime));   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DelayPlayerAppear(float time)
    {
        yield return new WaitForSeconds(time);
        standingSpriteObj.SetActive(false);
        playerObj.SetActive(true);
    }
}
