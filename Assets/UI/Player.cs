using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public bool isPlayerRightclicked;
    private LineCreator lineCreatorScript;
    public Line runningLine;
    public GameObject playButton;
    public PlayerMovement playerMovement;
    public int playerNumber;
    public static bool isLookingForPassRecipient;
    private LineDestroyer lineDestroyer;
   
    private void Start()
    {
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

    public void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("left clicked");

            EventTypeHandler.isDynamicEvent = true;
            isLookingForPassRecipient = true;
        }
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("right clicked");
            isPlayerRightclicked = true;
            lineCreatorScript.MakeLine();
        }
    }


    public void OnMouseUp()
    {
        if (Input.GetMouseButtonUp(1))
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
    