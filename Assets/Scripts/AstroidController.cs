using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
public class AstroidController : MonoBehaviour {

    Vector2 direction=Vector2.down;
    float speed = 6.0f;

    Rigidbody2D body;
    // Use this for initialization
    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        body.angularVelocity = Random.Range(-50.0f, 50.0f);
        body.velocity = direction * speed;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
