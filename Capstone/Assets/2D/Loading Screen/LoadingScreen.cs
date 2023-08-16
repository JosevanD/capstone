using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    [Header("Loading Screen Parameters")]
    //public GameObject loadingScreenObj;
    public float loadingScreenTime = 5;
    public Animator loadingScreenAnimator;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadingTime(loadingScreenTime));
    }

    IEnumerator LoadingTime(float time)
    {
        yield return new WaitForSeconds(time);

        loadingScreenAnimator.SetBool("_LoadingExit", true);
        
    }

    public void DestroyLoadingScreen()
    {
        Destroy(gameObject);
    }
}
