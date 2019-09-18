
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public bool isPlayerRightclicked;

    public void Update()
    {
        OnMouseDown();

       if (Input.GetMouseButtonUp(1)) isPlayerRightclicked = false;
    }
    //{
    //    
    //    

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("appy");
            isPlayerRightclicked = true;
        }
    }
    //private void OnMouseUp()
    //{
    //    if (Input.GetMouseButtonUp(1)) isPlayerRightclicked = false;
    //}
}