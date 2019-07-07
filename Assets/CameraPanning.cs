using UnityEngine;

public class CameraPanning : MonoBehaviour
{
    Vector3 cameraPosition;
    public double modulusMaxYValue;
    public double modulusMaxXValue;

    void Update()
    {
        cameraPosition = transform.position;

            if (Input.GetKeyDown("a") || Input.GetKey(KeyCode.LeftArrow))
            {
            if (cameraPosition.x <= -modulusMaxXValue) {}
            else cameraPosition.x = cameraPosition.x - 5f;
            }

        if (Input.GetKeyDown("w") || Input.GetKey(KeyCode.UpArrow))
            {
            if (cameraPosition.y >= modulusMaxYValue) {}
            else cameraPosition.y = cameraPosition.y + 5f;
        }
        if (Input.GetKeyDown("s") || Input.GetKey(KeyCode.DownArrow))
            {
            if (cameraPosition.y <= -modulusMaxYValue) {}
            else cameraPosition.y = cameraPosition.y - 5f;
            }
        if (Input.GetKeyDown("d") || Input.GetKey(KeyCode.RightArrow))
            {
            if (cameraPosition.x >= modulusMaxXValue) {}
            else cameraPosition.x = cameraPosition.x + 5f;
            }
        transform.position = cameraPosition;
    }
}
