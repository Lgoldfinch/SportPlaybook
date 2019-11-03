using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
public class Line : MonoBehaviour
{

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    public float lineSpacing;
	public GameObject player;
    public float tolerance;
    private List<Vector2> points;
    private Vector2 eventPositionInLine;

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
        if (EventModeButtonScript.isEventModeEnabled)
        {
            Vector2 clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

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
                    eventPositionInLine = points[i];
                    break;
                }
            }
            Debug.Log(eventPositionInLine);
        }
    }
        //{
        //    if (clickedPosition <= points[i]  || case2 == points[i] || case3 == points[i] || case4 == points[i]) Debug.Log("lol");

        //if (clickedPosition == (points[i].x +) Debug.Log("hi");  We would have to check per point whether the line was clicked to a certain tolerance for each of the cases
        //   } // these are x + 2 & y +2 | x + 2 & y -2 | x - 2 & y + 2 | x - 2 & y -2 | 

        //Vector3[] newPos = new Vector3[lineRenderer.positionCount];
        //Debug.Log(lineRenderer.GetPositions(newPos)).;


        //lineRenderer.GetPositions();
        //{
        //    var p

        //    for (int i = 0; i < lineRenderer.positionCount; i++)
        //    {
        //        if ( )
        //    }
        //}
    
}
 