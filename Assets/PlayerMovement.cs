using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 currentPositionHolder;
    private int currentPosition;
    private float timer;
    private float currentPositionX;
    private float currentPositionY;
    public GameObject playButton;
    private PlayButtonScript playButtonScript;
    private LineCreator lineCreator;

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
            List<Vector2> listOfPoints = playerScript.runningLine.GetLine();

            MovePlayer(listOfPoints);
        }
    }

    private void CheckLine(List<Vector2> listOfPoints)
    {
        timer = 0;
   
        currentPositionX = listOfPoints[currentPosition + 1].x;
        currentPositionY = listOfPoints[currentPosition + 1].y;

        currentPositionHolder = new Vector3(currentPositionX, currentPositionY);
    }

    public void MovePlayer(List<Vector2> listOfPoints)
    {
            if (currentPosition >= listOfPoints.Count - 2) // index is less than count MO
        {
            return;
        }

        else 
        {
            timer += Time.deltaTime * moveSpeed;

            //if(transform.position != currentPositionHolder)  

            if (transform.position != currentPositionHolder) // is position of the player different to the current position holder
            {
                if (currentPositionHolder == Vector3.zero) currentPositionHolder = listOfPoints.First(); 
                
                transform.position = Vector3.Lerp(transform.position, currentPositionHolder, timer);
                MovePlayer(listOfPoints);
            }

            else if (currentPosition < listOfPoints.Count - 1)
            {
                currentPosition++;
                CheckLine(listOfPoints);
            }
        }
        }    
}
