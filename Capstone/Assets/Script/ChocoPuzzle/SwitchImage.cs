using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchImage : MonoBehaviour
{
    public GameObject[] ChocolateImages;
    private int ImageCount = 0;
    private void Update()
    {
        if(ImageCount < ChocolateImages.Length -1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ImageCount++;
                ChocolateImages[ImageCount].SetActive(true);
                
                Debug.Log("Current Image No is " + ImageCount);
                
                ChocolateImages[ImageCount-1].SetActive(false);

                Debug.Log("last Image No is " + ImageCount);




            }


        }
        
        
    }

}
