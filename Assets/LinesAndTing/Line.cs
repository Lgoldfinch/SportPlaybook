using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Line : MonoBehaviour
{

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    public float lineSpacing;
	public GameObject player;
    GameObject existingLine;

    private List<Vector2> points;

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

    void AddPoint(Vector2 point) // Only call this function if a player has been double clicked
    {
        points.Add(point);

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);

        if (points.Count > 1)
        {
            edgeCollider.points = points.ToArray();
        }
    }
}
 