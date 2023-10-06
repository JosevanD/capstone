using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownTrigger : MonoBehaviour
{
    [Header("Slow dowm ")]
    public float MaxSpeed;
    public float SlowDownSpeed;
    private Charactor_Controller CharactorController;
    private void Start()
    {
        CharactorController = FindObjectOfType<Charactor_Controller>();
    }
   
    private void OnTriggerStay(Collider other)
    {
        

        if (other.gameObject.tag == "Player")
        {
            CharactorController.moveSpeed = Mathf.Lerp(CharactorController.moveSpeed, MaxSpeed, SlowDownSpeed);
            Debug.Log("Touched");

        }
    }
}
