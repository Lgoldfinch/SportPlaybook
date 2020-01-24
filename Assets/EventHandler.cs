using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public bool isAPlayerLookingForAPassRecipient;

    public EventInformation EventDelegator()
    {
            switch (EventTypeHandler.currentDynamicEventType)
            {
                case 0:
                    return gameObject.AddComponent<PassEvent>();

                //case 1:
                //    return new EventInformation(passerOfBall, EventTypeHandler.DynamicEventTypes.kick, false);
                //case 2:
                //    return new EventInformation(passerOfBall, EventTypeHandler.DynamicEventTypes.stopMovement, false);
                default: throw new System.Exception("Argument out of DynamicEventType range");
            }
        }
    }
