using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 currentPositionHolder;
    private int currentPositionInLine;
    private float currentPositionX;
    private float currentPositionY;
    public GameObject playButton;

    public IEnumerator MusterTheRohirrim(List<Vector2> listOfPoints)
    {
        currentPositionHolder = listOfPoints.First();

        while (currentPositionInLine <= listOfPoints.Count - 1)
        {
            transform.position = Vector3.Lerp(transform.position, currentPositionHolder, 1);
            yield return new WaitForEndOfFrame();
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
