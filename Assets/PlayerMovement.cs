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
        //if (playButtonScript.movementEnabled && lineCreator.lineExists)
        //{
        //    Player playerScript = gameObject.GetComponent<Player>();
        //    List<Vector2> listOfPoints = playerScript.runningLine.GetLine();

        //    MusterTheRohirrim(listOfPoints);
        //}
    }

    public void MusterTheRohirrim(List<Vector2> listOfPoints)
        
    {
        //Debug.Log("got here1");
        if (currentPosition >= listOfPoints.Count - 2) // index is less than count MO
        {
            //Debug.Log("got here2");

            return;
        }

        timer += Time.deltaTime * moveSpeed;

        if (transform.position != currentPositionHolder) // is position of the player different to the current position holder
        {
            Debug.Log("got here3");
            if (currentPositionHolder == Vector3.zero) currentPositionHolder = listOfPoints.First();

            transform.position = Vector3.Lerp(transform.position, currentPositionHolder, timer);
            MusterTheRohirrim(listOfPoints);
        }

        else if (currentPosition < listOfPoints.Count - 1)
        {
            Debug.Log("got here4");

            currentPosition++;
            CheckLine(listOfPoints);
        }
    }

    private void CheckLine(List<Vector2> listOfPoints)
    {
        timer = 0;

        Debug.Log("lineChecked");

        currentPositionX = listOfPoints[currentPosition + 1].x;
        currentPositionY = listOfPoints[currentPosition + 1].y;

        currentPositionHolder = new Vector3(currentPositionX, currentPositionY);
    }
}
