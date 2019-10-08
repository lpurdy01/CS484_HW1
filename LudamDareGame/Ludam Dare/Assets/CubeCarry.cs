using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCarry : MonoBehaviour
{

    private bool mouseIsOn;
    private bool isGrabbed = false;
    private Vector3 cameraLookingDirection;
    private Vector3 targetLocation;

    public float holdingDistance = 2;

    public GameObject grabbingCamera;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrabbed)
        {
            cameraLookingDirection = grabbingCamera.transform.forward;
            cameraLookingDirection = cameraLookingDirection * holdingDistance;
            targetLocation = grabbingCamera.transform.position + cameraLookingDirection;

            this.transform.position = targetLocation;
        }

        
    }
        void manageGrab()
    {
        if (!isGrabbed) isGrabbed = true;
        else isGrabbed = false;
        //SceneManager.LoadScene(1);
        Debug.Log("Oi! I've been grabbed!");
    }

    void OnMouseEnter()
    {
        mouseIsOn = true;
        GetComponent<Renderer>().material.color = Color.grey;
    }

    void OnMouseExit()
    {
        mouseIsOn = false;
        GetComponent<Renderer>().material.color = Color.black;
    }


    void OnMouseUp()
    {
        manageGrab();
    }
}
