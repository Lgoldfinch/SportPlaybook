using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    static Vector3 currentPositionHolder;
    private int currentPosition; 
    private float timer;
    private float currentPositionX;
    private float currentPositionY;
    public GameObject playButton;
    private PlayButtonScript playButtonScript;
    private LineCreator lineCreator;
    //private List<Vector2> lineCr

    private void Start()
    {
        playButtonScript = playButton.GetComponent<PlayButtonScript>();
        lineCreator = gameObject.GetComponent<LineCreator>();

    }

    private void Update()
    {
        if (playButtonScript.movementEnabled && lineCreator.lineExists)
        {
            Player playerScript = gameObject.GetComponent<Player>();
            MovePlayer(playerScript.runningLine.GetLine(), 0);

            //NullLineHandler(playerScript.runningLine);
        }
    }

    private void NullLineHandler(Line runningLine)
    {
        try
        {
            runningLine.GetLine();
        }
        catch (System.NullReferenceException)
        {
            return;
        }

    }

    private void CheckLine(List<Vector2> listOfPoints)
    {

        timer = 0;
        currentPositionX = listOfPoints[currentPosition + 1].x;
        currentPositionY = listOfPoints[currentPosition + 1].y;

        currentPositionHolder = new Vector3(currentPositionX, currentPositionY);
    }

    public void MovePlayer(List<Vector2> listOfPoints, int index)
    {
        if (index >= listOfPoints.Count - 1)
        {
            Debug.Log("bing");
            return;
        }
        else
        {
            timer += Time.deltaTime * moveSpeed;
            if (transform.position != currentPositionHolder)
            {
                transform.position = Vector3.Lerp(transform.position, currentPositionHolder, timer);
                MovePlayer(listOfPoints, index + 1);
                return;
            }

            else if (currentPosition < listOfPoints.Count - 1)
            {
                currentPosition++;
                CheckLine(listOfPoints);
            }

        }

        } 
    
}

// problems we have. Playert skips about when there is no line and you press play. ----> Have some way to negate anything unless a line exists.
// Player goes too far and you get an out of bounds index exception.
// There is   