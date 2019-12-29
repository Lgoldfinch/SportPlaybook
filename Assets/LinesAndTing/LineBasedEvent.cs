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
    public void MakeMarker(int positionForMarker, List<Vector2> points)
    {
        var eventHandler = eventHandlerObj.GetComponent<EventHandlerScript>();        
        
        GameObject makeYourMarker = Instantiate(marker);
        makeYourMarker.transform.SetParent(transform);
        makeYourMarker.transform.position = points[positionForMarker];
        eventHandler.EventDelegator(points[positionForMarker]);
        
        //for (int i = 0; i < eventsList.Count - 1; i++) // event is in the list waiting for value to be added to it.
        //{
        //   var a = eventsList.ToArray()[i];

        //}
        
    }

}
//Options:
// 1) Purely for the pass - click on the running line. Initial player will pass when he hits the marker.
//  Maybe click on the recipient player? Then that player will make the player move along the line over and over at the set pace
//  That will repeat until you click on the player, that will be the point at which the pass is made.

// 2) You click on the line - player 1 will pass the ball to player 2 when the first player reaches the marker.

// 3) You click on the first player and establish that he's gonna pass.
   // You then select a point on the second players line, pass will be delivered when second player reaches the marker. 





    // more thoughts, do I begin the pass when recipient player reaches the marker?

    // could have the player highlighted when he has the ball...
