
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Player : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isPlayerRightclicked;
    private LineCreator lineCreatorScript;
    public Line runningLine;
    public GameObject playButton;
    private PlayerMovement playerMovement;
    public bool isEventModeEnabled;
    public int playerNumber;

    private void Start()
    {

        lineCreatorScript = gameObject.GetComponent<LineCreator>();
        playerMovement = gameObject.GetComponent<PlayerMovement>();
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

        if (eventData.button == PointerEventData.InputButton.Left && EventTypeHandler.isDynamicEvent)
        {

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
    