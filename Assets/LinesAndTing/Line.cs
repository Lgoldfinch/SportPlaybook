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
    private (int, EventTypeHandler.DynamicEventTypes) eventInfo;

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
        EventTypeHandler.isDynamicEvent = true;

        if (EventModeButtonScript.isEventModeEnabled)
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
        EventTypeHandler eventTypeHandler = EventTypeButton.GetComponent<EventTypeHandler>();

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
               eventInfo = MakeEvent(eventPositionInLine); 
               break;
            }
        }
    }

    private (int, EventTypeHandler.DynamicEventTypes) MakeEvent(int eventPosition)
    {
        switch (EventTypeHandler.currentDynamicEventType)
        {
            case 0:
                return (eventPosition, EventTypeHandler.DynamicEventTypes.pass);
            case 1:
                return (eventPosition, EventTypeHandler.DynamicEventTypes.kick);
            case 2:
                return (eventPosition, EventTypeHandler.DynamicEventTypes.stopMovement);
            default: throw new System.Exception("Argument out of DynamicEventType range");
        }

    }
}
 