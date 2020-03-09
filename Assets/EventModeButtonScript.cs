using System;
using UnityEngine;

public class EventModeButtonScript : MonoBehaviour
{
    public static bool isEventModeEnabled;
    public bool hasEventSystemBeenInstantiated;
    public GameObject eventSystemPrefab;
    

    public enum EventMode
    {
        Disabled,
        Enabled
    }

    public void EnableOrDisableEvents() 
    {

        if (!hasEventSystemBeenInstantiated)
        {
            InstantiateEventSystem();
        }

        if (!isEventModeEnabled)
        {
            isEventModeEnabled = true;
            Debug.Log(isEventModeEnabled);
        }
        else isEventModeEnabled = false;

    }

    private GameObject InstantiateEventSystem()
    {
        hasEventSystemBeenInstantiated = true;
        return Instantiate(eventSystemPrefab);    
    }
}
