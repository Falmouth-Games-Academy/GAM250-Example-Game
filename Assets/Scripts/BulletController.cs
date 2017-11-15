using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class BulletController : MonoBehaviour {

    Rigidbody2D bulletRigidBody;

    [SerializeField]
    float speed=1.0f;
    [SerializeField]
    Vector2 direction=Vector2.up;

	// Use this for initialization
	void Start ()
    {
        direction = transform.up;
        bulletRigidBody = GetComponent<Rigidbody2D>();
        bulletRigidBody.velocity = direction * speed;
    }
}
