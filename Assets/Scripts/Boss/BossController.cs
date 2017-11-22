using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;

public class BossController : MonoBehaviour {

    public GameObject player;

    public GameObject bulletPrefab;
    public Transform[] bulletSpawns;
    public float fireCoolDown = 0.5f;
    float currentTime = 0;

    Blackboard bossBlackboard;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        bossBlackboard = GetComponent<Blackboard>();
    }

    public bool Fire()
    {
        currentTime += Time.deltaTime;
        if (currentTime > fireCoolDown)
        {
            foreach (Transform bulletSpawn in bulletSpawns)
            {
                Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.transform.rotation);
                Debug.Log("Shoot");
            }

            currentTime = 0.0f;
            return true;
        }

        return false;
    }
}
