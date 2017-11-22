using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;

public class Chase : StateBehaviour
{
    public GameObject player;
    public GameObject boss;

    public CharacterController characterController;

    // Update is called once per frame
    void Update () {
        Vector3 direction = player.transform.position - boss.transform.position;
        direction.Normalize();
        characterController.Move(direction * 2.0f * Time.deltaTime);
    }
}
