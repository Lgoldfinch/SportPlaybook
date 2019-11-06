using UnityEngine;
using System.Collections;
public class LineBasedEvent : MonoBehaviour
{

    private void Start() // Events will be triggered as the player moves along the line. So the event will have to be attached to a certain point in the line.
    {
        
    }

    public void DoEvent((int, EventTypeHandler.DynamicEventTypes) eventInfo) // DynamicEventTypes eventType) 
    {
        Debug.Log(eventInfo);
    }
    //public override void DoEvent<T, void>(T EventType)
    //{
    //    throw new System.NotImplementedException();
    //}
}
