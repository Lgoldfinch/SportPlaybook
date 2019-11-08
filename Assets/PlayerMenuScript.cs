using UnityEngine;

public class PlayerMenuScript : MonoBehaviour
{
    void Start()
    {
        Player[] players = gameObject.GetComponentsInChildren<Player>();
        for (int i = 0; i <= players.Length - 1; i++)
        {
            players[i].playerNumber = i + 1;
            players[i].SetPlayerKitNumber();
        }
    }  
}
