using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 currentPositionHolder;
    private int currentPosition;
    private float timer;
    private float lastTime = - 1;
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

    public IEnumerator MusterTheRohirrim(List<Vector2> listOfPoints)
    {
        //for (int currentPositionInLine = 0; currentPositionInLine <= listOfPoints.Count - 1; currentPositionInLine++) { //, we start at 0, add 1 every time we go through the loop.  
        // We use this index to adjust the current point the player is in the path.
        while (currentPosition <= listOfPoints.Count - 1)
        {
            if (currentPositionHolder == Vector3.zero)
            {
                currentPositionHolder = listOfPoints.First();
            }
            transform.position = Vector3.Lerp(transform.position, currentPositionHolder, 1);
            yield return new WaitForEndOfFrame();
            CheckLine(listOfPoints, currentPosition++);
        }
    }

    private void CheckLine(List<Vector2> listOfPoints, int currentPositionInLine)
    {

        currentPositionX = listOfPoints[currentPositionInLine].x;
        currentPositionY = listOfPoints[currentPositionInLine].y;

        currentPositionHolder = new Vector3(currentPositionX, currentPositionY);
    }
}
