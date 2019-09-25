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
    public GameObject player;
    public GameObject playButton;
    private PlayButtonScript playButtonScript;


    private void Start()
    {
        //playersLine = gameObject.GetComponentInChildren<Line>();

        playButtonScript = playButton.GetComponent<PlayButtonScript>(); 
    }

    private void Update()
    {
        if (playButtonScript.movementEnabled) {
            Player playerScript = player.GetComponent<Player>();
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

        MovePlayer(runningLine.GetLine());

    }

    void CheckLine(List<Vector2> listOfPoints)
    {
        timer = 0;
        currentPositionX = listOfPoints[currentPosition].x;
        currentPositionY = listOfPoints[currentPosition].y;

        currentPositionHolder = new Vector3(currentPositionX, currentPositionY);
    }

    public void MovePlayer(List<Vector2> listOfPoints)
    {
        //SetLine();
        Debug.Log("hi");
        //timer += Time.deltaTime * moveSpeed;
        //if (transform.position != currentPositionHolder)
        //{
        //    transform.position = Vector3.Lerp(transform.position, currentPositionHolder, timer);
        //}

        //else
        //{
        //    if (currentPosition < listOfPoints.Count - 1)
        //    {
        //        currentPosition++;
        //        CheckLine(listOfPoints);
            } // should only move if getLine returns something
        }
    

    //public void SetLine()
    //{
    //    playersLine = player.GetComponentInChildren<Line>();
    //    Debug.Log(playersLine);
    //    if (playersLine != null)
    //    {
    //        listOfPoints = playersLine.GetLine();
    //        Debug.Log("");
    //    }
    //    else Debug.Log("yooo");
    //}
