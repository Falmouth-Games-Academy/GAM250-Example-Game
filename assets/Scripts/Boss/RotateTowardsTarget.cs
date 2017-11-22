using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;

public class RotateTowardsTarget : ActionNode
{
    public override Status Update()
    {
        return Status.Running;
    }
}
