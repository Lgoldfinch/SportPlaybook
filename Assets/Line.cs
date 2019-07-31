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

    //go = GameObject.Find("goName"); // Find gameobject with name 'goName'.
    //  go = GameObject.FindWithTag("go"); // Finds gameobject with tag 'go'.

    private List<Vector2> points;

    public void UpdateLine(Vector2 mousePosition) // options are to vary the boolean or to see how many child components there are.
    {
        //Debug.Log(player.transform.childCount);
        //Debug.Log(player.transform.childCount == 2);
        //if (points == null && player.transform.childCount >= 2)
        //{
        //    Debug.Log("If statement hit");
        //   // lTransform = player.transform.Find("Line(clone)");
        //    //existingLine = GameObject.FindGameObjectWithTag("Lines");
        //    //Debug.Log(existingLine.ToString());
        //    Destroy(transform);
        //    points = new List<Vector2>();

        //    AddPoint(mousePosition);
        //    return;
        //}

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
 