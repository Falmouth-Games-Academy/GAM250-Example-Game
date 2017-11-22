using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;

public class MoveNode : ActionNode
{
    public Transform currentTransform;
    public CharacterController characterController;

    public Transform[] Waypoints;
    public float speed = 2.0f;
    public bool loopWaypoints = true;
    public float waypointDetectionDistance = 0.2f;
    int currentWaypointIndex = 0;

    public override void Start()
    {
        currentTransform = blackboard.gameObject.transform;
        characterController = blackboard.gameObject.GetComponent<CharacterController>();
    }

    public override Status Update()
    {
        Debug.Log("Move");
        Transform currentWaypoint = Waypoints[currentWaypointIndex];
        Vector3 direction = currentWaypoint.position - currentTransform.position;
        direction.Normalize();

        characterController.Move(direction * speed * Time.deltaTime);

        if (Vector3.Distance(currentTransform.position, currentWaypoint.position)< waypointDetectionDistance)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex > (Waypoints.Length - 1) && loopWaypoints)
            {
                currentWaypointIndex = 0;
            }
        }

        return Status.Success;
    }
}

