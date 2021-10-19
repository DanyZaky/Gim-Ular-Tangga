using System.Collections;
using UnityEngine;

public class FollowThePath : MonoBehaviour {

    public GameControl _gc;
    public Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 1f;
    public int currentWaypointIndex;

    public bool isMoveAllowed = false;
    public bool isForcedMove;
    public bool wasForcedMove;
    public int currentDestinationIndex;

	// Use this for initialization
	private void Start () {
        transform.position = new Vector2(-10, -3);
	}
	
	// Update is called once per frame
	private void Update () {
        if (isMoveAllowed)
        {
            Move();
        }
        if (isForcedMove)
        {
            ForcedMove();
        }
    }

    private void Move()
    {
        if (currentWaypointIndex < waypoints.Length && !_gc.reverse)
        {
            transform.position = Vector2.MoveTowards(transform.position,
            waypoints[currentWaypointIndex].transform.position,
            moveSpeed * Time.deltaTime);
            if (transform.position == waypoints[currentWaypointIndex].transform.position && currentWaypointIndex < waypoints.Length - 1)
            {
                currentWaypointIndex += 1;
            }
        }
        else if (_gc.reverse)
        {            
            transform.position = Vector2.MoveTowards(transform.position,
            waypoints[currentWaypointIndex].transform.position,
            moveSpeed * Time.deltaTime);
            if (transform.position == waypoints[currentWaypointIndex].transform.position && currentWaypointIndex != _gc.playerEndWaypoint - 1)
            {
                currentWaypointIndex -= 1;
            }
        }
    }

    void ForcedMove()
    {
        transform.position = Vector2.MoveTowards(transform.position,
        waypoints[currentDestinationIndex - 1].transform.position,
        moveSpeed * Time.deltaTime);
    }
}
