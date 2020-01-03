using UnityEngine;

public class EventModeButtonScript : MonoBehaviour
{ 
    public enum EventMode
    {
        Disabled,
        Enabled
    }

    public void EnableOrDisableEvents() 
    {
        if (!EventHandlerScript.isEventModeEnabled)
        {
            EventHandlerScript.isEventModeEnabled = true;
            Debug.Log(EventHandlerScript.isEventModeEnabled);
        }

        else EventHandlerScript.isEventModeEnabled = false;
    }
}
