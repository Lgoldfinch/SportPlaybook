
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isPlayerRightclicked;
    private LineCreator lineCreatorScript;

    private void Start()
    {
        lineCreatorScript = gameObject.GetComponent<LineCreator>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            isPlayerRightclicked = true;
            lineCreatorScript.MakeLine();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            //lineCreatorScript = gameObject.GetComponent<LineCreator>();
            lineCreatorScript.activeLine = null;
            isPlayerRightclicked = false;
        }
    }

    // so, at our disposal we have a click handler. We can use this to detect a click on the player.
    // we have the Exithandler. Could we do if

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    if (isPlayerRightclicked)
    //    {
    //        isPlayerRightclicked = false;
    //    }
    //}
}
    