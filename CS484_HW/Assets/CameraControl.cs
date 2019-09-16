using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    Vector2 rotation = new Vector2(0, 0);
    public float lookSpeed = 3;
    public float maxVertLookAngle = 30;
    private float currentLookAngle = 0;
    private float oldLookAngle = 0;
    private Vector3 baseOffset;
    public GameObject player;
    public float returnSpeed = 1;
    private float returnPower = 0;

    void Start()
    {
        baseOffset = transform.position;
    }


    // Update is called once per frame
    void LateUpdate()
    {
        float moveHorizontal = Input.GetAxis("Mouse X");
        float moveVertical = Input.GetAxis("Mouse Y");

        float rotY = Time.deltaTime * moveHorizontal * lookSpeed;  // Make sure the speed coresponds to the graphics refresh rate
        float rotX = Time.deltaTime * moveVertical * lookSpeed;

        oldLookAngle = currentLookAngle;
        currentLookAngle = currentLookAngle + rotX;
        Matrix4x4 m;


        if (Mathf.Abs(currentLookAngle) <= maxVertLookAngle)
        {
            Quaternion rotation = Quaternion.Euler(rotX, rotY, 0.0f); // Create a Rotation Quaternion
            m = Matrix4x4.Rotate(rotation);  // Create the rotation matrix 
        }
        else
        {
            //returnPower = -returnSpeed*currentLookAngle;
            Quaternion rotation = Quaternion.Euler(0.0f, rotY, 0.0f); // Create a Rotation Quaternion
            currentLookAngle = oldLookAngle; //This method could get the angle locked in top up view or top bottom view, because a fast look to corner will have to be overcome with the same velocity.
            //currentLookAngle = currentLookAngle + returnPower + rotX;
            m = Matrix4x4.Rotate(rotation);  // Create the rotation matrix 
        }


        baseOffset = m.MultiplyPoint3x4(baseOffset); // Rotate the base offset vector by multiplying it with the rotation matrix

        transform.position = player.transform.position + baseOffset; // Add the new rotated offset vector to the player position

        transform.LookAt(player.transform.position); // Position rotates, but I will use LookAt to simplify the final view.

        //rotation.y += Input.GetAxis("Mouse X");
        //rotation.x += -Input.GetAxis("Mouse Y");
        //transform.eulerAngles = (Vector2)rotation * lookSpeed;


    }
}
