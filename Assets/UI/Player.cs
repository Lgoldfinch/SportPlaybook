
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
    private EventHandler eventHandler;
    public GameObject eventSystemObj;

    private void Start()
    {
        playerMenuScript = playerMenu.GetComponent<PlayerMenuScript>();
        lineCreatorScript = gameObject.GetComponent<LineCreator>();
        playerMovement = gameObject.GetComponent<PlayerMovement>();
        lineDestroyer = gameObject.GetComponent<LineDestroyer>();
        eventHandler = eventSystemObj.GetComponent<EventHandler>();
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
            if (EventModeButtonScript.isEventModeEnabled)
            {
                EventTypeHandler.isDynamicEvent = true;
                eventHandler.isAPlayerLookingForAPassRecipient = true;
                playerMenuScript.passerOfBall = this;
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
}

//
    