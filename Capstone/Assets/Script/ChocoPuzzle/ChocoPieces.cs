using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine; 
using UnityEngine.EventSystems;

public class ChocoPieces : MonoBehaviour, IPointerDownHandler
{
    private BreakingChocoPieces breakingChocoPieces;
    //private float screenShakerTimer;

    //[Header("Screen Shake")]
    //public CinemachineVirtualCamera CinemachineVirtualCamera;
    private void Start()
    {
        breakingChocoPieces = FindObjectOfType<BreakingChocoPieces>();
        

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        breakingChocoPieces.SwitchChocoSprite(gameObject);
        breakingChocoPieces.brokenChocolateCount++;
        breakingChocoPieces.ShakeCamera(2f, 0.1f);
        gameObject.GetComponent<Image>().raycastTarget = false;
    
    }

    /*public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        screenShakerTimer = time;
    }
    private void Update()
    {
        if (screenShakerTimer > 0) {

            screenShakerTimer -= Time.deltaTime;
            if (screenShakerTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;

            }
        }

    }*/
}
