using UnityEngine;

public abstract class EventInformation : MonoBehaviour
{
    public EventTypeHandler.DynamicEventTypes eventType;
    public bool hasEventBeenMade;
    public Vector2 eventOriginPosition = Vector2.zero;
    public Vector2 eventEndPosition = Vector2.zero;

}
