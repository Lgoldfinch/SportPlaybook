using UnityEngine;
using System.Collections;
public class LineBasedEvent : MonoBehaviour
{

public void DoEvent((int, EventTypeHandler.DynamicEventTypes) eventInfo) // DynamicEventTypes eventType) 
    {
        if(eventInfo.Item2 == EventTypeHandler.DynamicEventTypes.pass)
        {
            Debug.Log("pass it");
        }

    }
    //public override void DoEvent<T, void>(T EventType)
    //{
    //    throw new System.NotImplementedException();
    //}
}
