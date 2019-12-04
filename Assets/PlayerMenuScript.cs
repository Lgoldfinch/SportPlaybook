using UnityEngine;

public class PlayerMenuScript : MonoBehaviour
{
    public Player passerOfBall;
    public static Player[] players;

    void Start()
    {
        players = gameObject.GetComponentsInChildren<Player>();
        for (int i = 0; i <= players.Length - 1; i++)
        {
            players[i].playerNumber = i + 1;
            players[i].SetPlayerKitNumber();
        }
    }

    public int GetNumberOfPlayers()
    { 
        PlayerArrayErrorHandling();

        return players.Length;
    }

    public Player FindPlayerByTheirNumber(int playerNumber)
    {
        Player requiredPlayer = null;

        for(int i = 0; i <= players.Length - 1; i++)
        {
            if (players[i].playerNumber == playerNumber)
            {
               requiredPlayer = players[i];
                break;
            }
        }
        return requiredPlayer;
    }

    private void PlayerArrayErrorHandling()
    {
        if (players == null || players.Length == 0)
        {
            Debug.LogWarning("Need players in the list for the rewind button to work.");
        }
    }
}
