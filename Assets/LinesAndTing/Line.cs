using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
public class Line : MonoBehaviour
{

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    public float lineSpacing;
	public GameObject player;
    public GameObject eventModeButton;
    private EventModeButtonScript eventModeButtonScript;

    private List<Vector2> points;

    //private void Start()
    //{
    //    eventModeButtonScript = eventModeButton.GetComponent<EventModeButtonScript>();
    //}

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
        //eventModeButtonScript = eventModeButton.GetComponent<EventModeButtonScript>();

        Debug.Log(EventModeButtonScript.isEventModeEnabled);
        if (EventModeButtonScript.isEventModeEnabled)
        {
            Debug.Log("yey");
        }
    }
}
 