using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanning : MonoBehaviour
{
    Vector3 cameraPosition;

    void Update()
    {
        cameraPosition = transform.position;

        if (Input.GetKeyDown("a") || Input.GetKey(KeyCode.LeftArrow))
            {
            cameraPosition.x = cameraPosition.x - 5f;
            Debug.Log("left");
            }

            if (Input.GetKeyDown("w") || Input.GetKey(KeyCode.UpArrow))
            {
            cameraPosition.y = cameraPosition.y + 5f;

            Debug.Log("up");

        }
        if (Input.GetKeyDown("s") || Input.GetKey(KeyCode.DownArrow))
            {
            cameraPosition.y = cameraPosition.y - 5f;
            Debug.Log("down");

        }
        if (Input.GetKeyDown("d") || Input.GetKey(KeyCode.RightArrow))
            {
            cameraPosition.x = cameraPosition.x + 5f;
            Debug.Log("right");
        }
        transform.position = cameraPosition;
    }
}
