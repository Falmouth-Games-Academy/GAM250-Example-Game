using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour {

    public float movementSpeed = 2.0f;

    public Collider2D leftScreenBounds;
    public Collider2D rightScreenBounds;
    public Collider2D topScreenBounds;
    public Collider2D bottomScreenBounds;

    public Collider2D playerCollider;

    public GameObject bulletPrefab;
    public GameObject bulletSpawnPoint;
    public AudioSource audioSource;

    public AudioClip laserSound;

    // Use this for initialization
    void Start () {
        playerCollider = GetComponent<PolygonCollider2D>();
        audioSource = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
        Vector2 moveAxis = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 moveDelta = moveAxis * movementSpeed * Time.deltaTime;
        
        if ( (leftScreenBounds.bounds.Intersects(playerCollider.bounds)))
        {
            transform.Translate(-0.1f, 0.0f, 0.0f);
        }
        else if (rightScreenBounds.bounds.Intersects(playerCollider.bounds))
        {
            transform.Translate(0.1f, 0.0f, 0.0f);
        }
        else if (topScreenBounds.bounds.Intersects(playerCollider.bounds))
        {
            transform.Translate(0.0f, -0.1f, 0.0f);
        }
        else if (bottomScreenBounds.bounds.Intersects(playerCollider.bounds))
        {
            transform.Translate(0.0f, 0.1f, 0.0f);
        }
        else
        {
            transform.Translate(moveDelta.x, moveDelta.y, 0.0f);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.transform.position,Quaternion.identity);
            audioSource.PlayOneShot(laserSound);
        }
	}
}
