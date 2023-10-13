using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveScript : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Dissolve/Appear")]
    public bool isDissolve;
    public MeshRenderer mesh;
    public float dissolveRate = 0.0125f;
    public float refreshRate = 0.025f;
    private Material[] meshMaterials;
    public bool startToAppear;
    public bool hasDissolved;
    public int doorNo;

    [Header("Sounds")]
    public AudioSource appearSound;
    public AudioSource dissolveSound;

    [Header("Animation")]
    public Animator doorAnimator;
    public float animDelay = 2;
    

    [Header("Colliders")]
    public BoxCollider doorCollider;
    public MeshCollider frameCollider;
    public BoxCollider enterDoorCollider;
    [SerializeField] GameObject toDisable;

    [Header("Others")]
    private GameObject sceneTracker;
    void Start()
    {
        sceneTracker = GameObject.Find("SceneTracker");

        if (mesh != null)
        {
            meshMaterials = mesh.materials;
        }

        if (isDissolve == false)
        {
            doorCollider.enabled = false;
            frameCollider.enabled = false;
            appearSound = GetComponent<AudioSource>();
        }

        if (isDissolve == true)
        {
            dissolveSound = GetComponent<AudioSource>();
        }
        
        if (startToAppear == true && isDissolve == false)
        {
            DoorAppear();
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && isDissolve ==  false)
        {
            DoorAppear();
        }

        if (hasDissolved == true)
        {
            Destroy(this);
        }
    }

    public void DoorAppear()
    {
        
            appearSound.enabled = true;
            doorCollider.enabled = true;
            frameCollider.enabled = true;
            //StartCoroutine(DissolveCor());
            StartCoroutine(MaterializeCor());
            StartCoroutine(StartAnim(animDelay));

    }

    public void DoorDissolve()
    {
        

        dissolveSound.enabled = true;
        doorCollider.enabled = false;
        frameCollider.enabled = false;
        enterDoorCollider.enabled = false;
        toDisable.SetActive(false);

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

    IEnumerator MaterializeCor()
    {
        if (meshMaterials.Length > 0)
        {
            float counter = 0;

            while (meshMaterials[0].GetFloat("_DissolveAmount") > 0)
            {
                counter += dissolveRate;
                for (int i = 0; i < meshMaterials.Length; i++)
                {
                    meshMaterials[i].SetFloat("_DissolveAmount", (1 - counter));
                }
                yield return new WaitForSeconds(refreshRate);
            }

        }
    }

    IEnumerator StartAnim(float time)
    {
        yield return new WaitForSeconds(time);

        doorAnimator.SetBool("DoorOpen", true);
    }

    public void HasDissolved()
    {
        hasDissolved = true;
    }
}
