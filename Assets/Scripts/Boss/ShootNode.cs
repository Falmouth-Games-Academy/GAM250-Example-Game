using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;

public class ShootNode : ActionNode
{
    public GameObject bulletPrefab;
    public Transform[] bulletSpawns;
    public float fireCoolDown = 0.5f;
    float currentTime = 0;

    public override Status Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > fireCoolDown)
        {
            foreach (Transform bulletSpawn in bulletSpawns)
            {
                //Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.transform.rotation);
                Debug.Log("Shoot");
            }

            currentTime = 0.0f;
        }
        return Status.Success;
    }
}
