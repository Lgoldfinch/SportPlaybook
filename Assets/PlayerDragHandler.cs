using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerDragHandler : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    //public void OnEndDrag(PointerEventData eventData)
    //{
    //    transform.localPosition = Vector2.zero;
    //}
}
// transform.localPosition = Vector2.zero; This will be useful for BinBehaviour. 
