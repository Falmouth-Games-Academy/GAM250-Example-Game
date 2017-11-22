using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;

public class CheckRangeNode : ConditionNode
{
    public Transform targetTransform;
    public Transform currentTransform;
    public float detectionRange;

    public override void Start()
    {
        targetTransform = blackboard.GetGameObjectVar("Target").transform;
        currentTransform = blackboard.gameObject.transform;

    }
    public override Status Update()
    {
        if (Vector3.Distance(currentTransform.position, targetTransform.position)<detectionRange)
        {
            Debug.Log("Found Player");
            return Status.Success;
        }

        return Status.Failure;
    }
}
