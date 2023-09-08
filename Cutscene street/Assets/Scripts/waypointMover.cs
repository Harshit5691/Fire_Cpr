using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointMover : MonoBehaviour
{
    // Stores a reference to the waypoint system this object will use
    [SerializeField] private wayPoints waypoints;

    [SerializeField] private float moveSpeed = 1f;

    [SerializeField] private float distanceThreshold = 0.1f;

    // The current waypoint target that the object is moving towards
    private Transform currentWaypoint;



    // Start is called before the first frame update
    void Start()
    {
        // Set initial position to the first waypoint
        currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
        transform.position = currentWaypoint.position;


        // Set the next waypoint target
        currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
        transform.LookAt(currentWaypoint);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
        {
            currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
            transform.LookAt(currentWaypoint);
        }
    }
}
