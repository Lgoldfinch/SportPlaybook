﻿using UnityEngine;
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
//Options:
// 1) Purely for the pass - click on the running line. Initial player will pass when he hits the marker.
//  Maybe click on the recipient player? Then that player will make the player move along the line over and over at the set pace
//  That will repeat until you click on the player, that will be the point at which the pass is made.

// 2) You click on the line - player 1 will pass the ball to player 2 when the first player reaches the marker.

// 3) You click on the first player and establish that he's gonna pass.
   // You then select a point on the second players line, pass will be delivered when second player reaches the marker. 

