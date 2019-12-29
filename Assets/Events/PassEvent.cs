using UnityEngine;

public class PassEvent : EventInformation
{
    public EventHandlerScript eventHandler;
    public Vector2 passOrigin = Vector2.zero;
    public Vector2 passEnd = Vector2.zero;
    
    public void Start()
    {
        eventHandler = gameObject.GetComponent<EventHandlerScript>();
    }

    public void PassBallToNextPlayer(PassEvent passEvent)
    {
        Debug.Log($"pass made from: {passEvent.passOrigin} to {passEvent.passEnd}");
    }

    public PassEvent MakePassEvent(Vector2 passOrig)//List<EventInformation> eventsList)
    {
        passOrigin = passOrig;
        eventHandler.AddEventToList(this);
        return this;
    }

    // we have a list on the the eventHandlerList
}