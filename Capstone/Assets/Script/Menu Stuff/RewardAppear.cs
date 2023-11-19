using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardAppear : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject[] rewardsSprObj;
    [SerializeField] private int rewardsCol;
    private GameObject sceneTrackerObj;
    void Awake()
    {
        
        sceneTrackerObj = GameObject.Find("SceneTracker");
        SetRewardsCollectedValue(sceneTrackerObj.GetComponent<SceneTracker>().rewardsCollected);
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void rewardsAppear()
    {
        int i = 0;

        while (i < rewardsCol)
        {
            rewardsSprObj[i].SetActive(true);
            i++;

        }
    }

    public void SetRewardsCollectedValue(int x)
    {
        rewardsCol = x;
    }

    private void OnEnable()
    {
        rewardsAppear();
    }
}
