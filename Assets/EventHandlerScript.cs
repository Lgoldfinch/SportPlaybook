﻿using System.Collections.Generic;
using UnityEngine;


public class EventHandlerScript : MonoBehaviour
{
    public List<EventInformation> eventsList;
    private PassEvent passEvent;

    public void Awake()
    {
        //Debug.Log(passEvent + "lool");
        //passEvent = gameObject.GetComponent<PassEvent>();
        //passEvent2 = passEvent.GetComponent<PassEvent>();
    }

    public List<EventInformation> AddEventToList(PassEvent eventInfo)
    {
        Debug.Log(eventInfo.passOrigin + "" + eventInfo.passEnd);
        eventsList.Add(eventInfo);
        //Debug.Log((PassEvent)eventsList.ToArray().GetValue(0));
        return eventsList;
    }

    //public EventInformation MakeEvent(Player passerOfBall)
    //{
    //   

//public PassEvent MakeEvent(Vector2 startOfPass, Vector2 endOfPass)
//{

//}


public EventInformation EventDelegator(Vector2 startPoint)
{// probably need to make an if statement to distinguish between static/dynamic
        passEvent = GetComponent<PassEvent>();

        switch (EventTypeHandler.currentDynamicEventType)
    {
        case 0:
            return passEvent.MakePassEvent(startPoint);
        //case 1:
        //    return new EventInformation(passerOfBall, EventTypeHandler.DynamicEventTypes.kick);
        //case 2:
        //    return new EventInformation(passerOfBall, EventTypeHandler.DynamicEventTypes.stopMovement);
        default: throw new System.Exception("Argument out of DynamicEventType range");
    }
}
}
