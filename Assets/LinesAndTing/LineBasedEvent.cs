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
                return new EventInformation(passerOfBall, EventTypeHandler.DynamicEventTypes.pass, false);
            case 1:
                return new EventInformation(passerOfBall, EventTypeHandler.DynamicEventTypes.kick, false);
            case 2:
                return new EventInformation(passerOfBall, EventTypeHandler.DynamicEventTypes.stopMovement, false);
            default: throw new System.Exception("Argument out of DynamicEventType range");
        }
    }
}