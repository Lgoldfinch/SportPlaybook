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
            var playerMovement = players[i].playerMovement;

            players[i].transform.position = beginningOfRunningLine;
            playerMovement.currentPositionX = 0;
            playerMovement.currentPositionY = 0;
            playerMovement.currentPositionInLine = 0;
        }
    }
}
