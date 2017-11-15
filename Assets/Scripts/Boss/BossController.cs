using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    public enum BossAIState
    {
        PATROL=0,
        FIRE,
    };

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

    public BossAIState currentState = BossAIState.PATROL;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        switch(currentState)
        {
            case BossAIState.PATROL:
                {
                    Patrol();
                    if (distance < detectionRange)
                    {
                        currentState = BossAIState.FIRE;
                    }
                    break;
                }

            case BossAIState.FIRE:
                {
                    Fire();
                    if (distance>detectionRange)
                    {
                        currentState = BossAIState.PATROL;
                    }
                    break;
                }

        }
    }

    void Patrol()
    {
        Transform currentWaypoint = Waypoints[currentWaypointIndex];

        Vector3 direction = currentWaypoint.position - transform.position;
        direction.Normalize();

        characterController.Move(direction * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentWaypoint.position) < waypointDetectionDistance)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex > (Waypoints.Length - 1) && loopWaypoints)
            {
                currentWaypointIndex = 0;
            }
        }
    }

    void Fire()
    {
        Vector3 v_diff = (player.transform.position - transform.position);
        float atan2 = Mathf.Atan2(v_diff.y, v_diff.x);
        transform.rotation = Quaternion.Euler(0f, 0f, (atan2 * Mathf.Rad2Deg) + 90.0f);

        currentTime += Time.deltaTime;
        if (currentTime > fireCoolDown)
        {
            foreach (Transform bulletSpawn in bulletSpawns)
            {
                Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.transform.rotation);
            }

            currentTime = 0.0f;
        }
    }
}
