using UnityEngine;

public class PlayerMenuScript : MonoBehaviour
{
    public Player passerOfBall;
    private Player[] players;

    void Start()
    {
        players = gameObject.GetComponentsInChildren<Player>();
        for (int i = 0; i <= players.Length - 1; i++)
        {
            players[i].playerNumber = i + 1;
            players[i].SetPlayerKitNumber();
        }
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
}
