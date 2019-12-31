using UnityEngine;

public class PassEvent : EventInformation
{
    private EventHandlerScript eventHandler;
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

    public PassEvent MakePassEventWithStart(Vector2 passOrig)//List<EventInformation> eventsList)
    {
        passOrigin = passOrig;
        eventHandler.AddEventToList(this);
        EventHandlerScript.isLookingForPassRecipient = false;
        return this;
    }

    public PassEvent MakePassEventWithEnd(Vector2 passEnd2)//List<EventInformation> eventsList)
    {
        passEnd = passEnd2;
        eventHandler.AddEventToList(this);
        EventHandlerScript.isLookingForPassRecipient = false;
        return this;
    }



    // so options
    // we instantiate a passEvent in player/line.
    // if done in make marker, we could add the start and not have an end. Would need to be replaced later.
    // im basing what im doing on isPlayerlooking...
}