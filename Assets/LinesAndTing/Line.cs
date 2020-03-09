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
    private LineBasedEvent lineEvents;

    private EventHandler eventHandler;
    public GameObject eventSystemObj;

    private int counter;
   
    private void Start()
    {
        lineEvents = GetComponent<LineBasedEvent>();
        eventHandler = eventSystemObj.GetComponent<EventHandler>();
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

        if (eventHandler.isAPlayerLookingForAPassRecipient)
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
                    eventInfo = lineEvents.EventDelegator(points[eventPositionInLine]);
                    counter++;
                }

                lineBasedEvent.MakeMarker(i, points);
                eventHandler.isAPlayerLookingForAPassRecipient = false;
                break;
            }
        }
    }
}

//I think that the problem comes from when you click the player when the line underneath is clickable.
// This only happens when event mode is on
// once the player has been clicked we could deactivate the player from being clicked.

    // could do this with isPlayerLooking....
    // Deactivate the player so it cant be moved - will have the implication that the player wont be movable.
    // If we're going down this road we might need to add another button.
    // so far, we have: eventmode, playerspeed, rewind button, eventType button. 