using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerDropHandler : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform playerList = transform as RectTransform;

        if (!RectTransformUtility.RectangleContainsScreenPoint(playerList, Input.mousePosition))
        {
            Debug.Log("Drop Player");
        }
    }
}
