using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
    public bool isPlayerRightclicked;
    private LineCreator lineCreatorScript;
    public Line runningLine;
    public GameObject playButton;
    public PlayerMovement playerMovement;
    public int playerNumber;
    public static bool isLookingForPassRecipient;

    private void Start()
    {
        lineCreatorScript = gameObject.GetComponent<LineCreator>();
        playerMovement = gameObject.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(1) && isPlayerRightclicked)
        {
            lineCreatorScript.activeLine = null;
            isPlayerRightclicked = false;
        }
    }

    public void GondorCallsForAid()
    {
        if (lineCreatorScript.lineExists)
        {
            StartCoroutine(playerMovement.MusterTheRohirrim(runningLine.GetLine()));
        }
    }

    public void OnMouseDown()
    {
        EventTypeHandler.isDynamicEvent = true;
        isLookingForPassRecipient = true;
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isPlayerRightclicked = true;
            lineCreatorScript.MakeLine();
        }
    }

    public void SetPlayerKitNumber()
    {
        Text text = gameObject.GetComponentInChildren<Text>();
        text.text = playerNumber.ToString();
    }
}
    