using UnityEngine;

public class LineBasedEvent : MonoBehaviour
{
    private int counter; 
    public void DoEvent((Player, EventTypeHandler.DynamicEventTypes) eventInfo) // DynamicEventTypes eventType) 
    {
        if(eventInfo.Item2 == EventTypeHandler.DynamicEventTypes.pass)
        {
            PassBallToNextPlayer(eventInfo.Item1);
        }

    }

    private void PassBallToNextPlayer(Player player)
    {
        counter++;
        Debug.Log($"pass to player : {player.playerNumber}");
        Debug.Log(counter);
    }

   
}
//Options:
// 1) Purely for the pass - click on the running line. Initial player will pass when he hits the marker.
//  Maybe click on the recipient player? Then that player will make the player move along the line over and over at the set pace
//  That will repeat until you click on the player, that will be the point at which the pass is made.

// 2) You click on the line - player 1 will pass the ball to player 2 when the first player reaches the marker.

// 3) You click on the first player and establish that he's gonna pass.
   // You then select a point on the second players line, pass will be delivered when second player reaches the marker. 

