using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomScript : MonoBehaviour
{
    public float speed = 0.1f;
    private float zoomSize = 110;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (zoomSize > 2)
            {
                zoomSize -= 5;
            }
        }

       else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (zoomSize < 110)
            { 
                zoomSize += 5;
            }

        }

        GetComponent<Camera>().orthographicSize = zoomSize;
    }
}
