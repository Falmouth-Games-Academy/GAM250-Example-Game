using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;

public class RotateTowardsTarget : ActionNode
{
    public Transform targetTransform;
    public Transform currentTransform;
    public float rotateSpeed = 0.5f;

    public override void Start()
    {
        targetTransform = blackboard.GetGameObjectVar("Target").transform;
        currentTransform = blackboard.gameObject.transform;
    }

    public override Status Update()
    {
        Vector3 targetDirection = targetTransform.position - currentTransform.position;

        float angle = (Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg)+90.0f;


        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        currentTransform.rotation = Quaternion.Slerp(currentTransform.rotation, q, Time.deltaTime * rotateSpeed);

        return Status.Success;
    }
}
