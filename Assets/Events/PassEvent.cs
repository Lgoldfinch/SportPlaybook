using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassEvent : EventInformation
{
    //private EventHandlerScript eventHandler;
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
        //eventHandler = GetComponent<EventHandlerScript>();
    }

    public void PassBallToNextPlayer(PassEvent passEvent)
    {
        Debug.Log($"pass made from: {passEvent.passOrigin} to {passEvent.passEnd}");
    }

}
