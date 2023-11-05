using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideTeleport : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject teleportObj;
    public void PlayerTeleportSlide()
    {
        player.transform.position = teleportObj.transform.position;
    }
}
