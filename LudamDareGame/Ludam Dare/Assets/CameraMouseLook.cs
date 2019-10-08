using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseLook : MonoBehaviour
{

    public float lookSpeed = 5.0f;
    public float smoothing = 2.0f;
    public GameObject playerCube;
    private Vector2 mouseRotator;
    private Vector2 smoothVar;
    // Start is called before the first frame update
    void Start()
    {
        playerCube = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // I'm putting the mouse inputs into one vec now with move
        var move = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        move = Vector2.Scale(move, new Vector2(lookSpeed * smoothing, lookSpeed * smoothing));


        smoothVar.x = Mathf.Lerp(smoothVar.x, move.x, 1f / smoothing);
        smoothVar.y = Mathf.Lerp(smoothVar.y, move.y, 1f / smoothing);

        mouseRotator += smoothVar;

        transform.localRotation = Quaternion.AngleAxis(-mouseRotator.y, Vector3.right);
        playerCube.transform.localRotation = Quaternion.AngleAxis(mouseRotator.x, playerCube.transform.up);
    }
}
