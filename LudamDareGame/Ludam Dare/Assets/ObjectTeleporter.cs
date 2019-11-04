using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class GlobalVariables
{
    public static float lookRotateXOffset;
}

public class ObjectTeleporter : MonoBehaviour
{

    public GameObject greenPortal1;
    public GameObject greenPortal2;
    public GameObject redPortal1;
    public GameObject redPortal2;
    public Vector3 rotationAngles;

    public float teleportOutDistance = -5; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        var rb = GetComponent<Rigidbody>();
        if (other.tag == "Green Portal")
        {
            rotationAngles = greenPortal1.transform.rotation.eulerAngles - greenPortal2.transform.rotation.eulerAngles;
            GlobalVariables.lookRotateXOffset = GlobalVariables.lookRotateXOffset + rotationAngles.y;
            //this.transform.localRotation = Quaternion.AngleAxis(rotationAngles.y, this.transform.up);
            this.transform.position = (greenPortal2.transform.right * teleportOutDistance) + greenPortal2.transform.position;
        }
        if (other.tag == "Green Portal 2")
        {
            rotationAngles = greenPortal2.transform.rotation.eulerAngles - greenPortal1.transform.rotation.eulerAngles;
            GlobalVariables.lookRotateXOffset = GlobalVariables.lookRotateXOffset + rotationAngles.y;
            //this.transform.localRotation = Quaternion.AngleAxis(rotationAngles.y, this.transform.up);
            this.transform.position = (greenPortal1.transform.right * teleportOutDistance) + greenPortal1.transform.position;
        }
        if (other.tag == "Red Portal")
        {
            rotationAngles = redPortal1.transform.rotation.eulerAngles - redPortal2.transform.rotation.eulerAngles;
            GlobalVariables.lookRotateXOffset = GlobalVariables.lookRotateXOffset + rotationAngles.y;
            this.transform.position = (redPortal2.transform.right * teleportOutDistance) + redPortal2.transform.position;
        }
        if (other.tag == "Red Portal 2")
        {
            rotationAngles = redPortal2.transform.rotation.eulerAngles - redPortal1.transform.rotation.eulerAngles;
            GlobalVariables.lookRotateXOffset = GlobalVariables.lookRotateXOffset + rotationAngles.y;
            this.transform.position = (redPortal1.transform.right * teleportOutDistance) + redPortal1.transform.position;
        }

    }

        // Update is called once per frame
    void Update()
    {
        
    }
}
