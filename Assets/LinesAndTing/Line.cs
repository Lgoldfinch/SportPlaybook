using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Line : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    public float lineSpacing;
	public GameObject player;
    public float tolerance;
    private List<Vector2> points;
    public int eventPositionInLine;
    public GameObject EventTypeButton;
    public EventInformation eventInfo; // do we need position in here? Maybe for other types of events.
    public GameObject marker;
    private EventHandler eventHandler;
    //public GameObject eventSystemObj;
    private int counter;

    private void Start()
    {
        //eventHandler = eventSystemObj.GetComponent<EventHandler>();
    }

    public void UpdateLine(Vector2 mousePosition) 
    {
       if (points == null)
        {
            points = new List<Vector2>();

            AddPoint(mousePosition);
            return;
        }

        if (Vector2.Distance(points.Last(), mousePosition) > lineSpacing)
        {
            AddPoint(mousePosition);
        }
    }
    
   private void AddPoint(Vector2 point) 
    {
        points.Add(point);

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);

        if (points.Count > 1)
        {
            edgeCollider.points = points.ToArray();
        }
    }

    public List<Vector2> GetLine()
    {
        return points;
    }

    public void OnMouseDown()
    {
        //var isPassMode = EventTypeHandler.currentDynamicEventType == (int)EventTypeHandler.DynamicEventTypes.pass;

        if (eventHandler.isAPlayerLookingForAPassRecipient) // ventModeButtonScript.isEventModeEnabled && isPassMode
        {
            Vector2 clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            while (eventPositionInLine == 0) // this is to cover the possibility that the tolerance isn't large enough to catch the line. 
            {
                FindNearestPositionInLine(clickedPosition);
                tolerance++;
            }
        }
    }

    private void FindNearestPositionInLine(Vector2 clickedPosition)
    {
        var playerMenuScript = GetComponentInParent<PlayerMenuScript>();
        var lineBasedEvent = GetComponent<LineBasedEvent>();

        var clickLocationX = clickedPosition.x;
        var clickLocationY = clickedPosition.y;

        var x1 = clickLocationX + tolerance;
        var x2 = clickLocationX - tolerance;

        var y1 = clickLocationY + tolerance;
        var y2 = clickLocationY - tolerance;

        for (int i = 0; i < lineRenderer.positionCount - 1; i++)
        {
            var pointsX = points[i].x;
            var pointsY = points[i].y;

            if (x2 <= pointsX && pointsX <= x1 && y2 <= pointsY && pointsY <= y1)
            { 
               eventPositionInLine = i;
                if (counter == 0)
                {
                    eventInfo = lineBasedEvent.MakeEvent(playerMenuScript.passerOfBall);
                    counter++;
                }

                lineBasedEvent.MakeMarker(i, points);
                eventHandler.isAPlayerLookingForAPassRecipient = false;
                break;
            }
        }
    }


}
 // event starts with the event button being clicked.
 // sets isEventTime or whatever to true.
 // Clicking on the line when this is true will place event marker at the nearest point.
 // The data type could just include an extra row and we could fill it.

    // We need to send the ball when the recipient player reachers the position 
    // when the second player hits the marker the first player needs to pass the ball 
    // we need to think of a way to send the number of the player that was previously clicked to the next player.


    // we need to pass the position of the pass from the recipient player to the 
