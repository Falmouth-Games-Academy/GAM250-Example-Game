using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;

public class MoveNode : ActionNode
{
    public Transform[] Waypoints;
    public CharacterController characterController;
    public float speed = 2.0f;
    public bool loopWaypoints = true;
    public float waypointDetectionDistance = 0.2f;
    public Transform bossTransform;
    int currentWaypointIndex = 0;

    public override Status Update()
    {
        Transform currentWaypoint = Waypoints[currentWaypointIndex];

        Vector3 direction = currentWaypoint.position - bossTransform.position;
        direction.Normalize();

        characterController.Move(direction * speed * Time.deltaTime);

        if (Vector3.Distance(bossTransform.position, currentWaypoint.position) < waypointDetectionDistance)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex > (Waypoints.Length - 1) && loopWaypoints)
            {
                currentWaypointIndex = 0;
            }
            return Status.Success;
        }

        return Status.Running;
        
    }
}

