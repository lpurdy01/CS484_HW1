using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Rotator : MonoBehaviour
{
    public GameObject player;
    private Vector3 baseOffset;
    public float rotSpeed;

    // Start is called before the first frame update
    void Start()
    {
        baseOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float rotXZ = Time.deltaTime * moveHorizontal * rotSpeed;

        //transform.RotateAround(player.transform.position, Vector3.up, rotXZ);

    }

    void LateUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Grab the horizontal user input

        float rotY = Time.deltaTime * moveHorizontal * rotSpeed;  // Make sure the speed coresponds to the graphics refresh rate

        Quaternion rotation = Quaternion.Euler(0.0f, rotY, 0.0f); // Create a Rotation Quaternion

        Matrix4x4 m = Matrix4x4.Rotate(rotation);  // Create the rotation matrix 

        baseOffset = m.MultiplyPoint3x4(baseOffset); // Rotate the base offset vector by multiplying it with the rotation matrix

        transform.position = player.transform.position + baseOffset; // Add the new rotated offset vector to the player position

        transform.LookAt(player.transform.position); // Position rotates, but I will use LookAt to simplify the final view.
    }
}
