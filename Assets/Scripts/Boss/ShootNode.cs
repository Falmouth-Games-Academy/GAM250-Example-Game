using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;

public class ShootNode : ActionNode
{
    BossController bossController;

    public override void Start()
    {
        bossController = blackboard.gameObject.GetComponent<BossController>();
    }

    public override Status Update()
    {
        bossController.Fire();

        return Status.Success;
    }
}
