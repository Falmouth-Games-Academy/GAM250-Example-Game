using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class EnemyController : MonoBehaviour {

    public Vector2 direction = Vector2.down;
    float speed = 6.0f;

    Rigidbody2D body;
    // Use this for initialization
    void Start () {
        
    }

    public void Move()
    {
        body = GetComponent<Rigidbody2D>();
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
