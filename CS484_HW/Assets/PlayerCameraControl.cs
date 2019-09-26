using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCameraControl : MonoBehaviour
{
    public float forwardSpeed;
    public float verticalSpeed;
    public GameObject camera;
    private Vector3 movementForceDirection;
    private float vertMove;
    public float sideMovemntAngle = 90;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        movementForceDirection = transform.position - camera.transform.position;
        Vector3 movementSideForceDirection = movementForceDirection;

        Matrix4x4 m;
        Quaternion rotation = Quaternion.Euler(0.0f, sideMovemntAngle, 0.0f); // Create a Rotation Quaternion
        m = Matrix4x4.Rotate(rotation);  // Create the rotation matrix 

        movementSideForceDirection = m.MultiplyPoint3x4(movementSideForceDirection); // Rotate the normal force direction vector by 90 degrees to allow for side force inputs.

        float moveHorizontal = Input.GetAxis("Vertical");
        float moveSide = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Jump");
        movementForceDirection = (movementForceDirection * moveHorizontal) + (movementSideForceDirection * moveSide);
        vertMove = moveVertical * verticalSpeed;
        movementForceDirection.y = vertMove;
        

        GetComponent<Rigidbody>().AddForce(movementForceDirection * forwardSpeed * Time.deltaTime);

    }
};
