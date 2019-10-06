using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    //public enum MovementType
    //{
    //    moveTowards,
    //    LerpTowards
    //}

    //public MovementType type = MovementType.moveTowards;
    public PlayerMovementTrial myPath; // we need to access this pat
    public float speed = 1;
    public float maxDistanceToGoal = .1f;
    private IEnumerator<Transform> pointinPath; // used to reference points returned from GetNextPathPoint

    void Start()
    {
        if (myPath == null)
        {
            Debug.LogError("gimme path", gameObject);
            return;
        }

        pointinPath = myPath.GetNextPathPoint();

        pointinPath.MoveNext();

        if (pointinPath.Current == null)
        {
            Debug.LogError("Need a path bru", gameObject);
            return;
        }

        // set position of this object to position of starting object
        transform.position = pointinPath.Current.position;
    }

    void Update()
    {
        if (pointinPath == null || pointinPath.Current == null) return;

        transform.position = Vector3.MoveTowards(transform.position,
            pointinPath.Current.position,
            Time.deltaTime + speed
            );
    }
}
