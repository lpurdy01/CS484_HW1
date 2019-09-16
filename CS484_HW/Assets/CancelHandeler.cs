using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CancelHandeler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float cancel = Input.GetAxis("Cancel");

        if (cancel > 0)
        {
            SceneManager.LoadScene(0);
        }
        
    }
}
