using UnityEngine;

public class PlayButtonScript : MonoBehaviour
{
    public GameObject playerMenu;

    public void LightTheBeacons()
    {
       Player[] playerScripts = playerMenu.GetComponentsInChildren<Player>();
        for (int i = 0; i < playerScripts.Length; i++) 
        {
            Player playerScript = (Player)playerScripts.GetValue(i);
            playerScript.GondorCallsForAid();
        }
    }
}
