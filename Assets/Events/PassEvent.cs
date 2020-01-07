using UnityEngine;

public class PassEvent : EventInformation
{
    private EventHandlerScript eventHandler;
    public Vector2 passOrigin = Vector2.zero;
    public Vector2 passEnd = Vector2.zero;
    public int passState;

    public enum PassState
    { 
        pendingPassState,
        playerLookingForRecipient,
        playerLookingToReceive,
    }
    
    public void Start()
    {
        eventHandler = GetComponent<EventHandlerScript>();
    }

    public void PassBallToNextPlayer(PassEvent passEvent)
    {
        Debug.Log($"pass made from: {passEvent.passOrigin} to {passEvent.passEnd}");
    }

    public PassEvent MakePassEventWithStart(Vector2 passOrig)//List<EventInformation> eventsList)
    {
        passOrigin = passOrig;
        eventHandler.AddEventToList(this);
        return this;
    }

    public PassEvent MakePassEventWithEnd(Vector2 passEnd2)//List<EventInformation> eventsList)
    {
        passEnd = passEnd2;
        eventHandler.AddEventToList(this);
        return this;
    }

    // so options:
    // we instantiate a passEvent in player/line.
    // if done in make marker, we could add the start and not have an end. Would need to be replaced later.

    // im basing what im doing on isPlayerlooking... which is in EventHandlerScript.
    // When a Line is clicked, it checks to see if a player is looking for a pass.
    // when a player is clicked and event mode is enabled, its set to true.
    // we dont have anything changing it to false.
    // only set this to false when the passEnd vector has been filled in.

    // I've looked at adding the component to the player when they're clicked on. However, at this point there's no way of telling what the event type is.
    // so how would we know what to add to the eventHandlerScript.
    // we could move the event delegator forward into the player...?

    // we got the passEvent in each Player. Where are we gonna add the start location? Line or lineBasedEvent surely? 
}