using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerDragHandler : MonoBehaviour, IDragHandler
{
    private ChangeTextOfButton ctScript;

    private void Awake()
    {
        GameObject drawOrDragBtn = GameObject.Find("DrawOrDragBtn");
        ctScript = drawOrDragBtn.GetComponent<ChangeTextOfButton>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (ctScript.isDragPlayerEnabled == true)
        {
            transform.position = eventData.position;
        }
    }

        //public void OnEndDrag(PointerEventData eventData)
        //{
        //    transform.localPosition = Vector2.zero;
        //}/
    }

// transform.localPosition = Vector2.zero; This will be useful for BinBehaviour. 
