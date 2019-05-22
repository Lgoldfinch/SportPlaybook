using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.color = Color.black;
    }
}
