using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine; 
using UnityEngine.EventSystems;

public class ChocoPieces : MonoBehaviour, IPointerDownHandler
{
    private BreakingChocoPieces breakingChocoPieces;
    [Header("Broken Choco Sprite")]
    public Sprite BrokenChocolateSprite;

    public GameObject BrokenChocolate;
    //private float screenShakerTimer;

    //[Header("Screen Shake")]
    //public CinemachineVirtualCamera CinemachineVirtualCamera;
    private void Start()
    {
        BrokenChocolate.SetActive(false);
        breakingChocoPieces = FindObjectOfType<BreakingChocoPieces>();
        

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        breakingChocoPieces.SwitchChocoSprite();
        breakingChocoPieces.brokenChocolateCount++;
        breakingChocoPieces.ShakeCamera(2f, 0.1f);
        gameObject.GetComponent<Image>().raycastTarget = false;
        BrokenChocolate.SetActive(true);
        gameObject.SetActive(false);
        //gameObject.GetComponent<Image>().sprite = BrokenChocolateSprite;

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
