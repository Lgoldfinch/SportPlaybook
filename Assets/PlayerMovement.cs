using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public int moveSpeed = 1;
    private Vector3 currentPositionHolder;
    private int currentPositionInLine;
    private float currentPositionX;
    private float currentPositionY;
    public GameObject playButton;


    public IEnumerator MusterTheRohirrim(List<Vector2> listOfPoints)
    {
        currentPositionHolder = listOfPoints.First(); // This line is needed so that the first point that the player moves to is not the default vector3(0,0,0). 

        while (currentPositionInLine <= listOfPoints.Count - 1)
        {
            transform.position = Vector3.Lerp(transform.position, currentPositionHolder, 1);
                        
                yield return moveSpeed;

            CheckLine(listOfPoints, currentPositionInLine++); // CheckLine uses the incremented value to provide the next position in the line for the player to move to.
        }
    }

    private void CheckLine(List<Vector2> listOfPoints, int nextPosition)
    {
        currentPositionX = listOfPoints[nextPosition].x;
        currentPositionY = listOfPoints[nextPosition].y;

        currentPositionHolder = new Vector3(currentPositionX, currentPositionY); // this is used by the lerp in the MusterTheRohirrim function
    }
}
// Do I have the movement speed multiply the number of frames spent at each point 