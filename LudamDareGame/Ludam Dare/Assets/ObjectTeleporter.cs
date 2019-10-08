using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTeleporter : MonoBehaviour
{

    public GameObject greenPortal1;
    public GameObject greenPortal2;
    public GameObject redPortal1;
    public GameObject redPortal2;

    public float teleportOutDistance = -5; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Green Portal")
        {
            this.transform.position = (greenPortal2.transform.forward * teleportOutDistance) + greenPortal2.transform.position;
        }
        if (other.tag == "Green Portal 2")
        {
            this.transform.position = (greenPortal1.transform.forward * teleportOutDistance) + greenPortal1.transform.position;
        }
        if (other.tag == "Red Portal")
        {
            this.transform.position = (redPortal2.transform.forward * teleportOutDistance) + redPortal2.transform.position;
        }
        if (other.tag == "Red Portal 2")
        {
            this.transform.position = (redPortal1.transform.forward * teleportOutDistance) + redPortal1.transform.position;
        }

    }

        // Update is called once per frame
    void Update()
    {
        
    }
}
