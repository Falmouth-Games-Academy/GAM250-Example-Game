using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;

public class CheckRangeNode : ActionNode
{
    public GameObject target;
    public Transform boss;
    public float detectionRange;

    public override Status Update()
    {
        Debug.Log("Checking Distance");
        if (Vector3.Distance(boss.position,target.transform.position)<detectionRange)
        {
            return Status.Success;
        }

        return Status.Failure;
    }
}
