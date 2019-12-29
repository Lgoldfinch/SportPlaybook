using System.Collections.Generic;
using UnityEngine;

public class PassEvent : EventInformation
{
    public EventHandlerScript eventHandler;
    private Vector2 start = Vector2.zero;
    private Vector2 end = Vector2.zero;
    
    public void Start()
    {
        eventHandler = gameObject.GetComponent<EventHandlerScript>();
        Debug.Log(eventHandler);
    }

    public PassEvent(Vector2 startOfPass, Vector2 endOfPass)
    {
        start = startOfPass;
        end = endOfPass;
    }

    public void PassBallToNextPlayer(PassEvent passEvent)
    {
        var eventy = new PassEvent(start, end);
        Debug.Log($"pass made from: {eventy.start} to {eventy.end}");
    }

    public PassEvent MakePassEvent(Vector2 passOrigin)//List<EventInformation> eventsList)
    {
        Debug.Log("hiii");
        var aba = new PassEvent(passOrigin, Vector2.zero);
        eventHandler.AddEventToList(aba);
        return aba;
    }
}