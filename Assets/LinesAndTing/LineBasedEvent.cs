using UnityEngine;
using System.Collections;
using System;

public class LineBasedEvent : MonoBehaviour
{

public void DoEvent((int, EventTypeHandler.DynamicEventTypes) eventInfo) // DynamicEventTypes eventType) 
    {
        if(eventInfo.Item2 == EventTypeHandler.DynamicEventTypes.pass)
        {
            PassBallToNextPlayer();
            Debug.Log("pass it");
        }

    }

    private void PassBallToNextPlayer()
    {
        
    }
    //public override void DoEvent<T, void>(T EventType)
    //{
    //    throw new System.NotImplementedException();
    //}
}
//Options:
// 1) Purely for the pass - click on the running line. Initial player will pass when he hits the marker.
//  Maybe click on the recipient player? Then that player will make the player move along the line over and over at the set pace
//  That will repeat until you click on the player, that will be the point at which the pass is made.

// 2) You click on the line - player 1 will pass the ball to player 2 when the second player reaches the marker.

// 3) 

