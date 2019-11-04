using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 10.0f;
    public float jumpForce = 10.0f;
    public Vector3 movement;
    private float forward;
    private float sideways;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // I just found this during this project makes a big difference
    }

    // Update is called once per frame
    void Update()
    {
        forward = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        sideways = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveVertical = Input.GetAxis("Jump") * jumpForce * Time.deltaTime;

        //movement = new Vector3(forward, sideways, moveVertical);

        //GetComponent<Rigidbody>().AddRelativeForce(movement);
        movement = new Vector3(sideways, 0.0f, forward);
        GetComponent<Rigidbody>().AddRelativeForce(movement);

        //transform.Translate(sideways, 0, forward);
    }
}
