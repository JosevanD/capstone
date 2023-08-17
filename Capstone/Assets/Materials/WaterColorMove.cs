using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterColorMove : MonoBehaviour
{
    public MeshRenderer mesh;

    private Material textureMaterial;

    public GameObject spriteSys;

    private bool isMovingRight;

    private bool isMovingLeft;

    public float scrollAmount;
    // Start is called before the first frame update
    void Start()
    {
        if (mesh != null)
        {
            textureMaterial = mesh.material;
        }


    }

    // Update is called once per frame
    void Update()
    {
        isMovingRight = spriteSys.GetComponent<SpriteSystem>().IsWalkRight();
        isMovingLeft = spriteSys.GetComponent<SpriteSystem>().IsWalkLeft();

        if (isMovingRight == true)
        {
            textureMaterial.SetFloat("_Scroll_value", textureMaterial.GetFloat("_Scroll_value") - scrollAmount);
        }

        if (isMovingLeft == true)
        {
            textureMaterial.SetFloat("_Scroll_value", textureMaterial.GetFloat("_Scroll_value") + scrollAmount);
        }
    }
}
