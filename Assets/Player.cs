
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public bool isPlayerclicked;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)) isPlayerclicked = true; 
    }

    private void OnMouseUp()
    {
        if (Input.GetMouseButtonUp(1)) isPlayerclicked = false;
    }
}