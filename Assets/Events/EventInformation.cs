using UnityEngine;

public abstract class EventInformation : MonoBehaviour
{
    public EventTypeHandler.DynamicEventTypes eventType;
    public bool hasEventBeenMade;
    public Vector2 eventOrigin = Vector2.zero;
    public Vector2 eventDestination = Vector2.zero;
}
