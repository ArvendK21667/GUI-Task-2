using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MouseHandler : MonoBehaviour
{
    public float mouseSensitivity = 500f;
    public Transform playerBody;
    float xRotation = 0f;

    private void Start()
    {
        
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; //Sets Axis
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; //Sets Axis

        
        xRotation -= mouseY; 
        xRotation = Mathf.Clamp(xRotation, -90, 90); //clamps rotation

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //rotates character
        playerBody.Rotate(Vector3.up* mouseX);

    }
}
