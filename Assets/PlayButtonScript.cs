using UnityEngine;

public class PlayButtonScript : MonoBehaviour
{
    public GameObject playerPanel;

    public void LightTheBeacons()
    {
       Player[] playerScripts = playerPanel.GetComponentsInChildren<Player>();
        for (int i = 0; i < playerScripts.Length; i++) 
        {
            Player playerScript = (Player)playerScripts.GetValue(i);
            playerScript.GondorCallsForAid();
        }
    }
}
