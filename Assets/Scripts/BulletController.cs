using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class BulletController : MonoBehaviour {

    Rigidbody2D bulletRigidBody;

    public float speed=1.0f;
    public Vector2 direction=Vector2.up;

	// Use this for initialization
	void Start ()
    {
        bulletRigidBody = GetComponent<Rigidbody2D>();
        bulletRigidBody.velocity = direction * speed;
    }
}
