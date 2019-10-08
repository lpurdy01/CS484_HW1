using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHighlightQuit : MonoBehaviour
{
    private bool mouseIsOn;
    // Start is called before the first frame update
    void Start()
    {
        Physics.queriesHitTriggers = true;
        GetComponent<Renderer>().material.color = Color.black;

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

        Application.Quit();
        Debug.Log("Over && Down");

    }
}
