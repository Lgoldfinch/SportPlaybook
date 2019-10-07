using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{

    public PlayerMovementTrial playerMovement; // we need to access this path
    public float speed = 1;
    public float maxDistanceToGoal = .1f;
    private PlayButtonScript playButtonScript;
    public GameObject playButton;

    private IEnumerator<Vector2> pointInPath; // used to reference points returned from GetNextPathPoint

    void Start()
    {
        playButtonScript = playButton.GetComponent<PlayButtonScript>();


        if (playerMovement == null)
        {
            Debug.LogError("gimme path", gameObject);
            return;
        }

        pointInPath = playerMovement.GetNextPathPoint();

        pointInPath.MoveNext();

        if (pointInPath.Current == Vector2.zero)
        {
            Debug.LogError("Need a path bru", gameObject);
            return;
        }

        // set position of this object to position of starting object
        transform.position = pointInPath.Current;
    }



    void Update()
     {

        if (pointInPath == null || pointInPath.Current == Vector2.zero) return;

        transform.position = Vector3.MoveTowards(transform.position,
            pointInPath.Current,
            Time.deltaTime + speed
            );
    }
}
