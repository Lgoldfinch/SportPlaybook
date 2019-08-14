using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerDragHandler : MonoBehaviour, IDragHandler
{

    //private ChangeTextOfButton changeTextScript;
    private LineCreator lineCreatorScript;

    private void Awake()
    {
        //GameObject drawOrDragBtn = GameObject.Find("DrawOrDragBtn");
        //changeTextScript = drawOrDragBtn.GetComponent<ChangeTextOfButton>();

        GameObject lineCreator = GameObject.Find("Player"); // this wont work when we have loads of players
        lineCreatorScript = lineCreator.GetComponent<LineCreator>();
    }

    public void OnDrag(PointerEventData eventData)
    {

        if (lineCreatorScript.isPlayerDraggable) transform.position = eventData.position;
        
    }
}

        //public void OnEndDrag(PointerEventData eventData)
        //{
        //    transform.localPosition = Vector2.zero;
        //}

// transform.localPosition = Vector2.zero; This will be useful for BinBehaviour. 
