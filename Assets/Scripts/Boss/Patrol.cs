using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;

public class Patrol : StateBehaviour
{
    public Transform[] Waypoints;
    public CharacterController characterController;
    public float speed = 2.0f;

    public bool loopWaypoints = true;
    public float waypointDetectionDistance = 0.2f;
    int currentWaypointIndex = 0;

	// Update is called once per frame
	void Update () {
        Move();
	}

    void Move()
    {
        Transform currentWaypoint = Waypoints[currentWaypointIndex];

        Vector3 direction = currentWaypoint.position - transform.position;
        direction.Normalize();

        characterController.Move(direction * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentWaypoint.position) < waypointDetectionDistance)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex > (Waypoints.Length - 1) && loopWaypoints)
            {
                currentWaypointIndex = 0;
            }
        }
    }
}
