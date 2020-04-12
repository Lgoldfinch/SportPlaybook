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

    public bool isLineBeingDrawn;

    public GameObject drawAndEditBtn;
    DrawAndEdit drawAndEditScript;

    public BoxCollider2D collider2d;

    private void Start()
    {
        lineCreatorScript = GetComponent<LineCreator>();
        playerMovement = GetComponent<PlayerMovement>();
        drawAndEditScript = drawAndEditBtn.GetComponent<DrawAndEdit>();

        collider2d = GetComponent<BoxCollider2D>();
}

 void Update()
    {
        if (Input.GetMouseButtonUp(0) && isLineBeingDrawn)
        {
            lineCreatorScript.activeLine = null;
            Debug.Log(isLineBeingDrawn);
            isLineBeingDrawn = false;
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
        if (drawAndEditScript.isDrawAndEditMode)
        {
            isLineBeingDrawn = true;
            lineCreatorScript.MakeLine();
        }

        //EventTypeHandler.isDynamicEvent = true;
        //isLookingForPassRecipient = true;
    }

    public void SetPlayerKitNumber()
    {
        Text text = gameObject.GetComponentInChildren<Text>();
        text.text = playerNumber.ToString();
    }
}
    