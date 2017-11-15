using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;

public class BossController : MonoBehaviour {

    public GameObject player;
    public Blackboard bossBlackboard;

    public float detectionRange = 5.0f;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        bossBlackboard = GetComponent<Blackboard>();

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 v_diff = (player.transform.position - transform.position);
        float atan2 = Mathf.Atan2(v_diff.y, v_diff.x);
        transform.rotation = Quaternion.Euler(0f, 0f, (atan2 * Mathf.Rad2Deg)+90.0f);

        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance<detectionRange)
        {
            bossBlackboard.SendEvent("PlayerInRange");
        }
        else
        {
            bossBlackboard.SendEvent("PlayerOutOfRange");
        }
    }
}
