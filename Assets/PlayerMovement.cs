using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading;

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

    public void MusterTheRohirrim(List<Vector2> listOfPoints)
    {
        for (int currentPositionInLine = 0; currentPositionInLine <= listOfPoints.Count - 1; currentPositionInLine++) { //, we start at 0, add 1 every time we go through the loop.  
            timer += Time.deltaTime;                                                                                                            // We use this index to adjust the current point the player is in the path.
            var rate = 1.0f / timer;

            if (currentPositionHolder == Vector3.zero)
                {
                    currentPositionHolder = listOfPoints.First();
                }
            transform.position = Vector3.Lerp(transform.position, currentPositionHolder, 0.2f);
                    CheckLine(listOfPoints, currentPositionInLine);               
        }    
    }

    private void CheckLine(List<Vector2> listOfPoints, int currentPositionInLine)
    {

        timer = 0;


        // delta = 0;

        //if (lastTime > 0)
        //{
        //    delta = Time.time - lastTime;
        //}

        //lastTime = Time.time;

        currentPositionX = listOfPoints[currentPositionInLine].x;
        currentPositionY = listOfPoints[currentPositionInLine].y;

        currentPositionHolder = new Vector3(currentPositionX, currentPositionY);
    }
}
