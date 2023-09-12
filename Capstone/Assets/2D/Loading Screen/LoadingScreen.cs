using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    [Header("Loading Screen Parameters")]
    //public GameObject loadingScreenObj;
    [SerializeField] private float loadingScreenTime = 5;
    [SerializeField] private Animator loadingScreenAnimator;
    [SerializeField] private float chapterNameTime = 3;
    [SerializeField] private GameObject chapterNameObj;
    [SerializeField] private GameObject controlsTextObj;
    [SerializeField] private GameObject walkingLoadingAnimObj;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadingTime(loadingScreenTime));
    }

    IEnumerator LoadingTime(float time)
    {
        yield return new WaitForSeconds(time);

        chapterNameObj.SetActive(true);

        loadingScreenAnimator.SetBool("_LoadingExit", true);

        
        
    }

    public void DestroyLoadingScreen()
    {
        Destroy(gameObject);
    }

    public void DestroyControlsText()
    {
        controlsTextObj.SetActive(false);
        walkingLoadingAnimObj.SetActive(false);
    }
}
