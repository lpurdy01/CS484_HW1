using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseHighlightStart : MonoBehaviour
{
    private bool mouseIsOn;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.black;

    }

    void onClickStart()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Over && Down");
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
        onClickStart();
    }
}
