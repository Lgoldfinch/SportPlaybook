using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerDragHandler : MonoBehaviour // IDragHandler
{
    private LineCreator lineCreatorScript;
    private float startPosX;
    private float startPosY;
    private bool isBeingHeld;

    private void Awake()
    {
        GameObject lineCreator = GameObject.Find("Player"); // this wont work when we have loads of players
        lineCreatorScript = lineCreator.GetComponent<LineCreator>();
    }

    //public void OnDrag(PointerEventData eventData)
    //{
    //    if (lineCreatorScript.isPlayerDraggable) transform.position = eventData.position;

    //}

    private void Update()
    {
       if(isBeingHeld == true)
        {
            Vector2 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.WorldToScreenPoint(mousePos);

            gameObject.transform.localPosition = new Vector2(mousePos.x - startPosX, mousePos.y - startPosY);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.WorldToScreenPoint(mousePos);

            startPosX = mousePos.x - transform.localPosition.x;
            startPosY = mousePos.y - transform.localPosition.y;
            isBeingHeld = true;
        }
    }

    private void OnMouseUp()
    {

        isBeingHeld = false;
    }

    //public void OnEndDrag(PointerEventData eventData)
    //{
    //    transform.localPosition = Vector2.zero;
    //}

    // transform.localPosition = Vector2.zero; This will be useful for BinBehaviour. 
}