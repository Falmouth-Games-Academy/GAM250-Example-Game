using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;

public class BossController : MonoBehaviour {

    public GameObject player;

    public float detectionRange = 5.0f;

    public GameObject bulletPrefab;
    public Transform[] bulletSpawns;
    public float fireCoolDown = 0.5f;
    float currentTime = 0;

    public Transform[] Waypoints;
    public CharacterController characterController;
    public float speed = 2.0f;
    public bool loopWaypoints = true;
    public float waypointDetectionDistance = 0.2f;
    int currentWaypointIndex = 0;

    Blackboard bossBlackboard;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        bossBlackboard = GetComponent<Blackboard>();
    }

}
