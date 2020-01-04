using UnityEngine;

public class EventTypeHandler : MonoBehaviour 
{
    public static bool isDynamicEvent;
    public static int currentDynamicEventType; // might not need two. 
    public static int currentStaticEventType;

public enum DynamicEventTypes
    {
        pass,
        kick,
        stopMovement
    }

    public enum StaticEventTypes
    {
        scrum,
        lineout,
        ruck,
    }

    public void ChangeEvent()
    {
        if (isDynamicEvent) DynamicEventCycle();
        else StaticEventCycle();
    }

    private DynamicEventTypes DynamicEventCycle()
    {
        if ((int)DynamicEventTypes.pass == currentDynamicEventType)
        {
            currentDynamicEventType = (int)DynamicEventTypes.kick;
            Debug.Log(currentDynamicEventType);
            return DynamicEventTypes.kick;
        }

        if ((int)DynamicEventTypes.kick == currentDynamicEventType)
        {
            currentDynamicEventType = (int)DynamicEventTypes.stopMovement;
            Debug.Log(currentDynamicEventType);
            return DynamicEventTypes.stopMovement;
        }

        if ((int)DynamicEventTypes.stopMovement == currentDynamicEventType)
        {
            currentDynamicEventType = (int)DynamicEventTypes.pass;
            Debug.Log(currentDynamicEventType);
            return DynamicEventTypes.pass;
        }

        throw new System.Exception("Argument out of DynamicEventType range");
    }

    private StaticEventTypes StaticEventCycle()
    {
        if ((int)StaticEventTypes.scrum == currentStaticEventType)
        {
            currentStaticEventType = (int)StaticEventTypes.lineout;
            return StaticEventTypes.lineout;
        }

        if ((int)StaticEventTypes.lineout == currentStaticEventType)
        {
            currentStaticEventType = (int)StaticEventTypes.ruck;
            return StaticEventTypes.ruck;
        }

        if ((int)StaticEventTypes.ruck == currentStaticEventType)
        {
            currentStaticEventType = (int)StaticEventTypes.scrum;
            return StaticEventTypes.scrum; 
        }

        throw new System.Exception("Argument out of StaticEventType range");
    }
}
