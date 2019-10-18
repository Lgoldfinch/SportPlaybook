using UnityEngine;

public class PlayButtonScript : MonoBehaviour
{
    //public bool movementEnabled;
    public GameObject playerPanel;

    public void LightTheBeacons()
    {
       Player[] playerScripts = playerPanel.GetComponentsInChildren<Player>();
        for (int i = 0; i < playerScripts.Length - 1; i++) // may need to cater for when all players have been dragged on the pitch? I dunno.
        {
            Player playerScript = (Player)playerScripts.GetValue(i);
            playerScript.GondorCallsForAid();
            //movementEnabled = true;
        }
    }
}
