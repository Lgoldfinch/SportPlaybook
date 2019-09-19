
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool isPlayerRightclicked;

    private void Update()
    {
        OnMouseDown();
        OnMouseUp();
    }

    public void OnMouseDown() // we have the getMouseButtons and we have OnMouseDown and OMU
    {
        if (Input.GetMouseButtonDown(1)) isPlayerRightclicked = true;
    }

    public void OnMouseUp()
    {

        if (Input.GetMouseButtonUp(1) && gameObject.transform.position == Input.mousePosition) isPlayerRightclicked = false;
    }
    //private void OnMouseDown()
    // {
    //     if (Input.GetMouseButtonDown(1)) isPlayerRightclicked = true;
    // }
}