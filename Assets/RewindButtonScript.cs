using UnityEngine;

public class RewindButtonScript : MonoBehaviour
{

    public void RewindPlayers()
    {
        var players = PlayerMenuScript.players;

        for (int i = 0; i <= players.Length - 1; i++)
        {
            if (players[i].runningLine == null) break; 

            var beginningOfRunningLine = players[i].runningLine.GetLine().ToArray()[0];

            players[i].transform.position = beginningOfRunningLine;
        }
    }
}


//Is movement deactivated after movement is completed? should be.
// if all players are at the end of their lines, deactivate movement.