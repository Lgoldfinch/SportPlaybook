using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Player : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isPlayerRightclicked;
    private LineCreator lineCreatorScript;
    public Line runningLine;
    public GameObject playButton;
    public PlayerMovement playerMovement;
    public int playerNumber;
    public GameObject playerMenu;
    private PlayerMenuScript playerMenuScript;
    private LineDestroyer lineDestroyer;
    public GameObject eventHandlerObj;
    private EventHandlerScript eventHandler;
    public bool isLookingForPassRecipient;
    public bool isLookingToRecieve;
    public bool leTrailblazer;
    public int passEventCount;
    private bool playerCanParticipateInEvents = true;

    private void Start()
    {
        eventHandler = eventHandlerObj.GetComponent<EventHandlerScript>();
        playerMenuScript = playerMenu.GetComponent<PlayerMenuScript>();
        lineCreatorScript = gameObject.GetComponent<LineCreator>();
        playerMovement = gameObject.GetComponent<PlayerMovement>();
        lineDestroyer = gameObject.GetComponent<LineDestroyer>();
    }

    public void GondorCallsForAid()
    {
        if (lineCreatorScript.lineExists)
        {
            StartCoroutine(playerMovement.MusterTheRohirrim(runningLine.GetLine()));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            isPlayerRightclicked = true;
            lineCreatorScript.MakeLine();

        }

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (EventHandlerScript.isEventModeEnabled)
            {
                EventTypeHandler.isDynamicEvent = true;

               if (playerCanParticipateInEvents) {
                    playerCanParticipateInEvents = false;
                }
                playerMenuScript.passerOfBall = this; // pretty sure this line needs to be deleted.
            }

            lineDestroyer.DeleteLine(transform);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            lineCreatorScript.activeLine = null;
            isPlayerRightclicked = false;
        }
    }

    public void SetPlayerKitNumber()
    {
        Text text = gameObject.GetComponentInChildren<Text>();
        text.text = playerNumber.ToString();
    }

    //public EventInformation EventDelegator()
    //{// probably need to make an if statement to distinguish between static/dynamic

    //    switch (EventTypeHandler.currentDynamicEventType)
    //    {
    //        case 0:
    //            return 

    //        //gameObject.AddComponent<PassEvent>();
    //        //var passComponent = GetComponent<PassEvent>();
    //        //eventHandler.AddEventToList(passComponent);
    //        //return passComponent;

    //        //case 1:
    //        //    return new EventInformation(passerOfBall, EventTypeHandler.DynamicEventTypes.kick);
    //        //case 2:
    //        //    return new EventInformation(passerOfBall, EventTypeHandler.DynamicEventTypes.stopMovement);
    //        default: throw new System.Exception("Argument out of DynamicEventType range");
    //    }

    //}
}
    // could make a for loop that will go through the list of players
    // and gather all events into the list.
    // options, we have the lastPlayerClicked in the eventHandler.../