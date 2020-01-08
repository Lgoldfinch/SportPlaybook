using UnityEngine;
using System.Collections.Generic;

public class LineBasedEvent : MonoBehaviour
{
    public GameObject marker;
    public PassEvent passEvent;
    public GameObject eventHandlerObj;

    public void DoEvent(EventInformation eventInfo) 
    {
        if(eventInfo.eventType == EventTypeHandler.DynamicEventTypes.pass)
        {
            passEvent.PassBallToNextPlayer((PassEvent)eventInfo);
        }
    }
    public void MakeMarker(int positionForMarker, List<Vector2> points, bool isStartOfMove)
    {
        var eventHandler = eventHandlerObj.GetComponent<EventHandlerScript>();        
        
        GameObject makeYourMarker = Instantiate(marker);
        makeYourMarker.transform.SetParent(transform);
        makeYourMarker.transform.position = points[positionForMarker];
        //eventHandler.EventDelegator(points[positionForMarker]); // could add the passEvent to the Line here?  
    }
}