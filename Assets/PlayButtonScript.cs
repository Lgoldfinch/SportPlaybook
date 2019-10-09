using UnityEngine;

public class PlayButtonScript : MonoBehaviour
{
    public bool movementEnabled;

    public void LightTheBeacons()
    {
        movementEnabled = true;
    }
}