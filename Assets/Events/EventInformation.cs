using UnityEngine;

abstract class EventInformation : MonoBehaviour
{
    public Player playerWithBall;
    public EventTypeHandler.DynamicEventTypes dynamicEvent;
    public EventTypeHandler.StaticEventTypes staticEvent;

    public bool hasEventBeenMade;

    public EventInformation(
        EventTypeHandler.DynamicEventTypes anEventType
    {
        dynamicEvent = anEventType;
        hasEventBeenMade = hasEventBeenMade2;
    }

    public EventInformation(
       EventTypeHandler.StaticEventTypes anEventType,
       bool hasEventBeenMade2)
    {
        staticEvent = anEventType;
        hasEventBeenMade = hasEventBeenMade2;
    }
}
