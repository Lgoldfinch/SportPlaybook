using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public  int moveSpeed = 1;
    private Vector2 currentPositionHolder;
    public  int currentPositionInLine;
    public  float currentPositionX;
    public  float currentPositionY;
    public  GameObject playButton;
    private Line runningLine;
    private LineBasedEvent eventHandler;
    private float angleOfPlayer;

    public IEnumerator MusterTheRohirrim(List<Vector2> listOfPoints)
    {
        runningLine  = GetComponentInChildren<Line>();
        eventHandler = GetComponentInChildren<LineBasedEvent>();
        currentPositionHolder = listOfPoints.First(); // This line is needed so that the first point that the player moves to is not the default vector3(0,0,0). 

        while (currentPositionInLine <= listOfPoints.Count - 1)
        {
            if (currentPositionInLine == runningLine.eventPositionInLine && runningLine.eventInfo != null) // if the second player is at the point in the line where the event is due.
            {
                runningLine.eventInfo.hasEventBeenMade = true;
                //eventHandler.DoEvent(runningLine.eventInfo);
            }

            AdjustPlayerAngle();

            transform.position = Vector2.Lerp(transform.position, currentPositionHolder, 1);
                        
                yield return moveSpeed;
            
            CheckLine(listOfPoints, currentPositionInLine++); // CheckLine uses the incremented value to provide the next position in the line for the player to move to.
        }
    } 

    private void CheckLine(List<Vector2> listOfPoints, int nextPosition)
    {
        currentPositionX = listOfPoints[nextPosition].x;
        currentPositionY = listOfPoints[nextPosition].y;

        currentPositionHolder = new Vector2(currentPositionX, currentPositionY); // this is used by the lerp in the MusterTheRohirrim function
    }

    private float AdjustPlayerAngle()
    {
        Vector2[] points = runningLine.GetLine().ToArray();
        Vector2 currentPoint = points[currentPositionInLine];

        if (currentPositionInLine + 1 >= points.Length)
        {
            transform.Rotate(Vector3.forward * angleOfPlayer);
            return angleOfPlayer;
        }

        Vector2 nextPoint = points[currentPositionInLine + 1];

        angleOfPlayer = Vector2.Angle(currentPoint, nextPoint);

        transform.Rotate(Vector3.forward * angleOfPlayer);

        return angleOfPlayer;
    }
}

