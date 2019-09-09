using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    public float speed;
    public float bounceMultiplier;
    public float rotSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(0.0f , Mathf.Abs(moveVertical) * bounceMultiplier, moveVertical);
        

        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
        GetComponent<Rigidbody>().AddRelativeTorque(transform.up * rotSpeed * Time.deltaTime * moveHorizontal);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
