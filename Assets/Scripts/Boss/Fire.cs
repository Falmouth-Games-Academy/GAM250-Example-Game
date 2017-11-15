using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;

public class Fire : StateBehaviour
{

    public GameObject bulletPrefab;
    public Transform[] bulletSpawns;
    public float fireCoolDown = 0.5f;

    float currentTime = 0;

	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
        if (currentTime>fireCoolDown)
        {
            DoFire();
            currentTime = 0.0f;
        }
    }

    void DoFire()
    {
        foreach (Transform bulletSpawn in bulletSpawns)
        {
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.transform.rotation);
        }
    }
}
