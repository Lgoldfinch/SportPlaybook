using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Line playersLine;
    public float moveSpeed;
    static Vector3 currentPositionHolder;
    private int currentPosition; 
    //private List<Vector2> listOfPoints;
    private float timer;
    private float currentPositionX;
    private float currentPositionY;
    public GameObject playButton;
    private PlayButtonScript playButtonScript;
    private Vector3 startPosition; 


    private void Start()
    {
        playButtonScript = playButton.GetComponent<PlayButtonScript>();
    }

    private void Update()
    {
        if (playButtonScript.movementEnabled)
        {
            Debug.Log("another attempt");
            Player playerScript = gameObject.GetComponent<Player>();
            NullLineHandler(playerScript.runningLine);
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

        MovePlayer(runningLine.GetLine(), 0);
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
        timer += Time.deltaTime * moveSpeed;
        if (transform.position != currentPositionHolder)
        {
            transform.position = Vector3.Lerp(transform.position, currentPositionHolder, timer);
             MovePlayer(listOfPoints, index + 1);
            return;
        }

        else
        {
            if (currentPosition < listOfPoints.Count - 1)
            {
                currentPosition++;
                CheckLine(listOfPoints);
            }
        }
    }
}