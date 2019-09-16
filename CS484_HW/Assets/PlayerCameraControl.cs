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
        float moveHorizontal = Input.GetAxis("Vertical");
        float moveVertical = Input.GetAxis("Jump");
        movementForceDirection = movementForceDirection * moveHorizontal;
        vertMove = moveVertical * verticalSpeed;
        movementForceDirection.y = vertMove;
        

        GetComponent<Rigidbody>().AddForce(movementForceDirection * forwardSpeed * Time.deltaTime);

    }
};
