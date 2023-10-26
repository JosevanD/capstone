using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private static CursorManager cursorManager;

    [SerializeField] Texture2D cursorDefault;
    [SerializeField] Texture2D cursorPalm;
    [SerializeField] Texture2D cursorGrab;
    [SerializeField] Texture2D cursorDraw;

    [SerializeField] bool isCursorLocked;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        SetCursorDefault();
        if (isCursorLocked == true)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }

        DontDestroyOnLoad(transform.gameObject);

        //ensuring no duplicates
        if (cursorManager == null)
        {
            cursorManager = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangeCursor(Texture2D cursorType, bool isMiddleHotspot)
    {

        if (isMiddleHotspot == true)
        {
            Vector2 hotspot = new Vector2(cursorType.width / 2, cursorType.height / 2);
            Cursor.SetCursor(cursorType, hotspot, CursorMode.Auto);
        }
        if (isMiddleHotspot == false)
        {
            Vector2 hotspot = new Vector2(0, 0);
            Cursor.SetCursor(cursorType, hotspot, CursorMode.Auto);
        }
    }

    public void SetCursorDefault()  //sets cursor to default cursor
    {
        ChangeCursor(cursorDefault, false);
    }

    public void ChangeToDraw() //sets cursor to draw cursor
    {
        ChangeCursor(cursorDraw, false);
    }

    public void ChangeToPalm() //sets cursor to open hand
    {
        ChangeCursor(cursorPalm, true);
    }
    
    public void ChangeToGrab() //sets cursor to grabbing hand
    {
        ChangeCursor(cursorGrab, true);
    }
}
