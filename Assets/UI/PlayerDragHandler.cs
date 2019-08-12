using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerDragHandler : MonoBehaviour, IDragHandler
{
    private ChangeTextOfButton ctScript;

    public void OnDrag(PointerEventData eventData)
    {
        GameObject eh = GameObject.Find("DrawOrDragBtn"); // I reckon write a helper function for this. Ugly AF 
        ctScript = eh.GetComponent<ChangeTextOfButton>();

        if (ctScript.isDragPlayerEnabled == true)
        {
            transform.position = eventData.position;
        }
    }

        //public void OnEndDrag(PointerEventData eventData)
        //{
        //    transform.localPosition = Vector2.zero;
        //}
    }

// transform.localPosition = Vector2.zero; This will be useful for BinBehaviour. 
