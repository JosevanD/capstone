using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RotateContainer : MonoBehaviour
{

    /*public Vector3 mousePos;
    public Transform targetTransform;


    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

        //transform.rotation = Quaternion
    }
    */

    private Vector3 mouseStart;
    private float startRotation;

    public void OnPointerDown()
    {
        // Record the mouse position when the object is clicked.
        mouseStart = Input.mousePosition;
        // Record the initial rotation of the object in degrees.
        startRotation = transform.eulerAngles.z;
    }

    public void OnDrag()
    {
        // Calculate the current mouse position and rotation angle.
        Vector3 mouseDelta = Input.mousePosition - mouseStart;
        float rotationAngle = Mathf.Atan2(mouseDelta.y, mouseDelta.x) * Mathf.Rad2Deg;

        // Apply the rotation to the object.
        transform.eulerAngles = new Vector3(0, 0, startRotation + rotationAngle);
        
    }

}
