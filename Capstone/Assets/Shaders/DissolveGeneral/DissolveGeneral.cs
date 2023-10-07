using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveGeneral : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Dissolve/Appear")]
    [SerializeField] bool isDissolve;
    [SerializeField] MeshRenderer mesh;
    [SerializeField] float dissolveRate = 0.0125f;
    [SerializeField] float refreshRate = 0.025f;
    private Material[] meshMaterials;
    [SerializeField] bool hasDissolved;
    [SerializeField] int doorNo;

    //[Header("Sounds")]
    //[SerializeField] AudioSource appearSound;
    //[SerializeField] AudioSource dissolveSound;
    
    [Header("Others")]
    private GameObject sceneTracker;
    void Start()
    {
        sceneTracker = GameObject.Find("SceneTracker");

        if (mesh != null)
        {
            meshMaterials = mesh.materials;
        }


        DissolveStart();
    }

    // Update is called once per frame
    void Update()
    {

        if (hasDissolved == true)
        {
            Destroy(this);
        }
    }


    public void DissolveStart()
    {

        //dissolveSound.enabled = true;

        StartCoroutine(DissolveCor());

        Destroy(this, 2);
    }


    IEnumerator DissolveCor()
    {
        if (meshMaterials.Length > 0)
        {
            float counter = 0;

            while (meshMaterials[0].GetFloat("_DissolveAmount") < 1)
            {
                counter += dissolveRate;
                for (int i=0; i<meshMaterials.Length; i++)
                {
                    meshMaterials[i].SetFloat("_DissolveAmount", counter);
                }
                yield return new WaitForSeconds(refreshRate);
                sceneTracker.GetComponent<SceneTracker>().CheckDoorDissolved(doorNo);
            }

        }
    }

    public void HasDissolved()
    {
        hasDissolved = true;
    }
}
