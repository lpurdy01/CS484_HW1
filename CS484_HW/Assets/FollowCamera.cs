using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Vector3 baseOffset;
    public GameObject player;
    public float cameraAngleAbove = 1;
    public float targetCameraAngleAbove = 1;
    public float verticalLookRatio = 0.2f; 
    public float lookSpeed = 400;
    public float verticalReturnSpeed = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        baseOffset = player.transform.position - transform.position;

        float vertdiff = player.transform.position.y - transform.position.y;
        float horizontalDistance = Mathf.Sqrt(Mathf.Pow(player.transform.position.x - transform.position.x, 2) +
            Mathf.Pow(player.transform.position.z - transform.position.x, 2));

        cameraAngleAbove = Mathf.Atan(vertdiff / horizontalDistance);
        targetCameraAngleAbove = cameraAngleAbove;
    }

    // Update is called once per frame
    void Update()
    {
        float vertdiff = player.transform.position.y - transform.position.y;
        float horizontalDistance = Mathf.Sqrt(Mathf.Pow(player.transform.position.x - transform.position.x, 2) +
            Mathf.Pow(player.transform.position.z - transform.position.x,2));

        cameraAngleAbove = Mathf.Atan(vertdiff / horizontalDistance);

    }

    void LateUpdate()
    {
        float moveHorizontal = Input.GetAxis("Mouse X");
        float moveVertical = Input.GetAxis("Mouse Y");

        float rotY = Time.deltaTime * moveHorizontal * lookSpeed;  // Make sure the speed coresponds to the graphics refresh rate
        float rotX = Time.deltaTime * moveVertical * lookSpeed * verticalLookRatio;
        
        Matrix4x4 m;
        Quaternion rotation = Quaternion.Euler(0.0f, rotY, 0.0f); // Create a Rotation Quaternion
        m = Matrix4x4.Rotate(rotation);  // Create the rotation matrix 

        baseOffset = m.MultiplyPoint3x4(baseOffset); // Rotate the base offset vector by multiplying it with the rotation matrix

        baseOffset.y = (baseOffset.y + rotX) + (verticalReturnSpeed* (cameraAngleAbove - targetCameraAngleAbove));

        transform.position = player.transform.position + baseOffset; // Add the new rotated offset vector to the player position

        transform.LookAt(player.transform.position); // Position rotates, but I will use LookAt to simplify the final view.


    }
}
