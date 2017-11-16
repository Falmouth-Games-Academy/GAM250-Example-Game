using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;

public class RotateTowards : ActionNode
{
    public GameObject player;
    public Transform boss;

    public override Status Update()
    {
        Vector3 v_diff = (player.transform.position - boss.position);
        float atan2 = Mathf.Atan2(v_diff.y, v_diff.x);
        boss.rotation = Quaternion.Euler(0f, 0f, (atan2 * Mathf.Rad2Deg) + 90.0f);

        return Status.Running;
    }
}
