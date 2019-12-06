using UnityEngine;
using System.Collections.Generic;

public class LineBasedEvent : MonoBehaviour
{
    public GameObject marker;

    public void DoEvent(EventInformation eventInfo) // DynamicEventTypes eventType) 
    {
        if(eventInfo.eventType == EventTypeHandler.DynamicEventTypes.pass)
        {
            PassBallToNextPlayer(eventInfo.playerWithBall);
        }
    }

    private void PassBallToNextPlayer(Player playerWithBall)
    { 
        Debug.Log($"pass received from player : {playerWithBall.playerNumber}");

    }


    public void MakeMarker(int positionForMarker, List<Vector2> points)
    {
        GameObject makeYourMarker = Instantiate(marker);
        makeYourMarker.transform.position = points[positionForMarker];
}

public EventInformation MakeEvent(Player passerOfBall)
    {
        switch (EventTypeHandler.currentDynamicEventType)
        {
            case 0:
                return new PassEvent(passerOfBall, EventTypeHandler.DynamicEventTypes.pass);
            case 1:
                return new EventInformation(passerOfBall, EventTypeHandler.DynamicEventTypes.kick);
            case 2:
                return new EventInformation(passerOfBall, EventTypeHandler.DynamicEventTypes.stopMovement);
            default: throw new System.Exception("Argument out of DynamicEventType range");
        }
    }
}




    // more thoughts, do I begin the pass when recipient player reaches the marker?

    // could have the player highlighted when he has the ball...
