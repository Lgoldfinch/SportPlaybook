using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTrial : MonoBehaviour
{

    public int movementDirection = 1; // 1 clockwise forward etc etc. 
    public int movingTo = 0; // identify point in path sequence we're moving to 
    public GameObject player;
    public GameObject playButton;
    private PlayButtonScript playButtonScript;
    public float moveSpeed;
    private Player playerScript;
    private Line runningLine1;

    private void Start()
    {
        playButtonScript = playButton.GetComponent<PlayButtonScript>();
    }

    //private void Update()
    //{
    //    if (playButtonScript.movementEnabled)
    //    {
    //        playerScript = player.GetComponent<Player>();
    //        runningLine1 = playerScript.runningLine;
    //        NullLineHandler(runningLine1);

    //    }
    //}

    //private void NullLineHandler(Line runningLine2)
    //{
    //    try
    //    {
    //        runningLine2.GetLine();
    //    }
    //    catch (System.NullReferenceException)
    //    {
    //        return;
    //    }
    //    GetNextPathPoint();
    //}

    public IEnumerator<Vector2> GetNextPathPoint()
    {

       List<Vector2> line = runningLine1.GetLine();

        if(line == null || line.Count - 1 < 1) // checks whether it constitutes a path.
        {
            yield break; // function returns an object that implements the IEnumerable interface
            // if a calling function starts foreaching over this object the function is called again until it yields.
        }

        while (true) // does not infinite loop due to yield return 
        {
            //Return the current point in pathsequence
            yield return line[movingTo];
            ////////////////////////////////// pauses here ////////////////////////

            ///// if there is only one point exit the coroutine

            if (line.Count - 1 == 1) continue;

            {
                //beginning of the line
                if (movingTo <= 0) movingTo = movingTo + 1;

                // reached end of the line.
                else if (movingTo >= line.Count - 1) { }
                    //playButtonScript.movementEnabled = false;
            }
        }

    }
}
