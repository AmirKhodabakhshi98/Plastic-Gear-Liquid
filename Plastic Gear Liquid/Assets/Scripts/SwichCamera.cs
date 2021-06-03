using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwichCamera : MonoBehaviour
{
    public Camera mainCamera;
    public Camera highCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera.enabled = true;
        highCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        //This will toggle the enabled state of the two cameras between true and false each time
        if (Input.GetKeyUp(KeyCode.Return))
        {
            mainCamera.enabled = !mainCamera.enabled;
            highCamera.enabled = !highCamera.enabled;

        }
    }
}
