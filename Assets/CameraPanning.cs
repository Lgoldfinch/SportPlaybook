using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanning : MonoBehaviour
{
    Vector2 cameraPosition;

    void Update()
    {
        cameraPosition = transform.position;

        if (Input.GetKeyDown("a") || Input.GetKey(KeyCode.LeftArrow))
            {
                cameraPosition.x = cameraPosition.x - 5;
            Debug.Log("left");
            }

            if (Input.GetKeyDown("w") || Input.GetKey(KeyCode.UpArrow))
            {
            cameraPosition[1] = cameraPosition.y + 5;
            Debug.Log("up");

        }
        if (Input.GetKeyDown("s") || Input.GetKey(KeyCode.DownArrow))
            {
            cameraPosition[1] = cameraPosition.y - 5;
            Debug.Log("down");

        }
        if (Input.GetKeyDown("d") || Input.GetKey(KeyCode.RightArrow))
            {
            cameraPosition[0] = cameraPosition.x + 5;
            Debug.Log("right");

        }
    }
}
