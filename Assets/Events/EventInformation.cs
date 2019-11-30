
public class EventInformation
{
    public Player playerWithBall;
    public EventTypeHandler.DynamicEventTypes eventType;
    public bool hasEventBeenMade;

    public EventInformation(
        Player aPlayerWithBall,
        EventTypeHandler.DynamicEventTypes anEventType,
        bool hasEventBeenMade2)
    {
        playerWithBall = aPlayerWithBall;
        eventType = anEventType;
        hasEventBeenMade = hasEventBeenMade2;
    }
}
