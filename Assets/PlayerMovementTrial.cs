using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTrial : MonoBehaviour
{
    public enum PathTypes
    {
        linear
    }

    public PathTypes pathType;
    public int movementDirection = 1; // 1 clockwise forward etc etc. 
    public int movingTo = 0; // identify point in path sequence we're moving to 
    public Transform[] pathSequence; // array of all points in the path
    private float timer;
    private float currentPositionX;
    private float currentPositionY;
    public GameObject player;
    public GameObject playButton;
    private PlayButtonScript playButtonScript;
    public float moveSpeed;
    static Vector3 currentPositionHolder;
    private int currentPosition;

    private void Start()
    {
        playButtonScript = playButton.GetComponent<PlayButtonScript>();
    }

    private void Update()
    {
        if (playButtonScript.movementEnabled)
        {
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

        MovePlayer(runningLine.GetLine(), 0);
        playButtonScript.movementEnabled = false;
    }

    public IEnumerator<Transform> GetNextPathPoint()
    {
        if(pathSequence == null || pathSequence.Length < 1) // checks whether it constitutes a path.
        {
            yield break; // function returns an object that implements the IEnumerable interface
            // if a calling function starts foreaching over this object the function is called again until it yields.
        }

        while (true) // does not infinite loop due to yield return 
        {
            //Return the current point in pathsequence
            yield return pathSequence[movingTo];
            ////////////////////////////////// pauses here ////////////////////////

            ///// if there is only one point exit the coroutine

            if (pathSequence.Length == 1) continue;

            if (pathType == PathTypes.linear)           // this will always be true
            {
                //beginning of the line
                if (movingTo <= 0) movementDirection = 1;
                else if (movingTo >= pathSequence.Length) movementDirection = -1; // reached end of the line.

            }

            movingTo = movingTo + movementDirection; // we can just add one until we reach the end right?
        }

    }

   

}
