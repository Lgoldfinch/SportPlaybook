using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Line : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    public float lineSpacing;
    public float tolerance;
    private List<Vector2> points;
    public int eventPositionInLine;
    public GameObject EventTypeButton;
    public EventInformation eventInfo; 
    public GameObject marker;
    public GameObject eventHandlerObj;


    private Player player;

    private void Start()
    {
        player = GetComponentInParent<Player>();
        Debug.Log(player);
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
        var eventHandler = eventHandlerObj.GetComponent<EventHandlerScript>();

        //var isPassMode = EventTypeHandler.currentDynamicEventType == (int)EventTypeHandler.DynamicEventTypes.pass;
        if (EventHandlerScript.isEventModeEnabled)
        {
            Vector2 clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            while (eventPositionInLine == 0) // this is to cover the possibility that the tolerance isn't large enough to catch the line. 
            {
                FindNearestPositionInLine(clickedPosition);
                tolerance++;
            }

           
        }
    }

    private Vector2 FindNearestPositionInLine(Vector2 clickedPosition)
    {
        var lineBasedEvent = GetComponent<LineBasedEvent>();

        var clickPositionX = clickedPosition.x;
        var clickPositionY = clickedPosition.y;

        var x1 = clickPositionX + tolerance;
        var x2 = clickPositionX - tolerance;

        var y1 = clickPositionY + tolerance;
        var y2 = clickPositionY - tolerance;

        var pointsX = 0f;
        var pointsY = 0f;

        for (int i = 0; i < lineRenderer.positionCount - 1; i++)
        {
             pointsX = points[i].x;
             pointsY = points[i].y;

            if (x2 <= pointsX && pointsX <= x1 && y2 <= pointsY && pointsY <= y1)
            {
                eventPositionInLine = i;
                ModifyPassEvent(points[eventPositionInLine]); // this should probably be done in the event handler.
                break;
            }
        }
        return new Vector2(pointsX, pointsY);
    }

    public void ModifyPassEvent(Vector2 eventPosition)
    {
        var passEvent = player.GetComponent<PassEvent>();

        if (!EventHandlerScript.isLookingForPassRecipient) // after the second player is clicked we have mirrored start and end between the two players
        {            // We need this to not be static then. If each player had its individual variable we could determine which half of the event would be filled.
            passEvent.passOrigin = eventPosition;
            EventHandlerScript.isLookingForPassRecipient = true;

        }

        else if (EventHandlerScript.isLookingForPassRecipient)
        {
            passEvent.passEnd = eventPosition;
            EventHandlerScript.isLookingForPassRecipient = false;

        }


        //var mostRecentEvent = EventHandlerScript.events.Last();

        //if (mostRecentEvent is PassEvent) // getting the last one in the list will guarantee that you'll get the most recent event made.
        //{
        ////((PassEvent)EventHandlerScript.events.Last()).passOrigin = points[eventPositionInLine];
        //}
        // only add the passEvent from the player to the eventHandler script when the origin and the end are known.

        //if (EventHandlerScript.isLookingForPassRecipient)
        //{
        //    lineBasedEvent.MakeMarker(eventPositionInLine, points, true);
        //}

        //else if (!EventHandlerScript.isLookingForPassRecipient)
        //{
        //    lineBasedEvent.MakeMarker(eventPositionInLine, points, false);

        //}


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