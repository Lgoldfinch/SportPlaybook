using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // World-units per second.
    public float moveSpeed = 1f;

    // Current vertex index in the player's running line.
    public int currentPositionInLine;
    public float currentPositionX;
    public float currentPositionY;

    // Extra rotation to match the sprite's "forward" direction.
    public float rotationOffsetDegrees = 0f;

    private Line runningLine;
    private LineBasedEvent eventHandler;

    public IEnumerator MusterTheRohirrim(List<Vector2> listOfPoints)
    {
        runningLine = GetComponentInChildren<Line>();
        eventHandler = GetComponentInChildren<LineBasedEvent>();

        if (listOfPoints == null || listOfPoints.Count == 0)
            yield break;

        currentPositionInLine = Mathf.Clamp(currentPositionInLine, 0, listOfPoints.Count - 1);

        // Snap to the starting vertex immediately.
        currentPositionX = listOfPoints[currentPositionInLine].x;
        currentPositionY = listOfPoints[currentPositionInLine].y;
        transform.position = listOfPoints[currentPositionInLine];
        TryTriggerEventAtCurrentVertex();
        UpdateFacing(listOfPoints, currentPositionInLine);

        // Walk vertex-to-vertex.
        while (currentPositionInLine < listOfPoints.Count - 1)
        {
            Vector2 nextPoint = listOfPoints[currentPositionInLine + 1];
            while (Vector2.Distance(transform.position, nextPoint) > 0.01f)
            {
                UpdateFacing(listOfPoints, currentPositionInLine);
                transform.position = Vector2.MoveTowards(transform.position, nextPoint, moveSpeed * Time.deltaTime);
                yield return null;
            }

            currentPositionInLine++;
            currentPositionX = listOfPoints[currentPositionInLine].x;
            currentPositionY = listOfPoints[currentPositionInLine].y;

            // Trigger when the player arrives at this vertex.
            TryTriggerEventAtCurrentVertex();
        }
    }

    private void TryTriggerEventAtCurrentVertex()
    {
        if (runningLine == null)
            return;

        if (runningLine.eventInfo == null)
            return;

        if (currentPositionInLine != runningLine.eventPositionInLine)
            return;

        // The event execution is currently stubbed; we at least mark it as having happened.
        runningLine.eventInfo.hasEventBeenMade = true;
        //eventHandler.DoEvent(runningLine.eventInfo);
    }

    private void UpdateFacing(List<Vector2> points, int currentIndex)
    {
        if (points == null || points.Count < 2)
            return;

        Vector2 from;
        Vector2 to;

        if (currentIndex + 1 < points.Count)
        {
            from = points[currentIndex];
            to = points[currentIndex + 1];
        }
        else
        {
            // Last vertex: face from the previous segment.
            from = points[currentIndex - 1];
            to = points[currentIndex];
        }

        Vector2 dir = to - from;
        if (dir.sqrMagnitude < 0.0001f)
            return;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle + rotationOffsetDegrees);
    }
}

