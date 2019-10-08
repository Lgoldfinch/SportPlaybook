using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{

    private PlayerMovementTrial playerMovement; // we need to access this path
    public float speed = 1;
    public float maxDistanceToGoal = .1f;
    private PlayButtonScript playButtonScript;
    public GameObject player;
    public GameObject playButton;
    private Player playerScript;
    private Line runningLine1;

    private IEnumerator<Vector2> pointInPath; // used to reference points returned from GetNextPathPoint

    void Start()
    {
        playButtonScript = playButton.GetComponent<PlayButtonScript>();

    }


     private void Update()
    {
        Debug.Log(playButtonScript.movementEnabled);

        if (playButtonScript.movementEnabled)
        {
            playerScript = player.GetComponent<Player>();
            runningLine1 = playerScript.runningLine;
            NullLineHandler(runningLine1);
            Saloon();
        }

        //Debug.Log(pointInPath);
        if (pointInPath == null || pointInPath.Current == Vector2.zero)
        {
            //Debug.Log("point in path problem");
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position,
            pointInPath.Current,
            Time.deltaTime + speed
            );


    }
        //if (playerMovement == null)
        //{
        //    Debug.LogError("gimme path", gameObject);
        //    return;
        //}

   

        //if (pointInPath.Current == Vector2.zero)
        //{
        //    Debug.LogError("Need a path bru", gameObject);
        //    return;
        //}
    

  

    private void NullLineHandler(Line runningLine2)
    {
        try
        {
            Debug.Log("NullHandler reached");
            runningLine2.GetLine();
        }
        catch (System.NullReferenceException)
        {
            return;
        }
        Saloon();
    }

    private void Saloon()
    {
        Debug.Log("Saloon reached");

        pointInPath = playerMovement.GetNextPathPoint();

        pointInPath.MoveNext();

        // set position of this object to position of starting object
        transform.position = pointInPath.Current;
    }
}
