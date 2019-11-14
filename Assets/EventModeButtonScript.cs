using UnityEngine;

public class EventModeButtonScript : MonoBehaviour
{
    public static bool isEventModeEnabled;

    public enum EventMode
    {
        Disabled,
        Enabled
    }

    public void EnableOrDisableEvents() 
    {
        if (!isEventModeEnabled)
        {
            isEventModeEnabled = true;
            Debug.Log(isEventModeEnabled);
        }
        else isEventModeEnabled = false;
    }
}
