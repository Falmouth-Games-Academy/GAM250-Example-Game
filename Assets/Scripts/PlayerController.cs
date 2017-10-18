using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class GameBounds
{
    public Collider2D leftScreenBounds;
    public Collider2D rightScreenBounds;
    public Collider2D topScreenBounds;
    public Collider2D bottomScreenBounds;
}

[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    [Range(2.0f,10.0f)]
    float movementSpeed = 2.0f;

    [SerializeField]
    Vector2 direction;

    [Header("Bounds")]
    [SerializeField]
    GameBounds bounds;

    Collider2D playerCollider;

    [Header("Bullets")]
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    GameObject bulletSpawnPoint;

    [Header("Sounds")]
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip laserSound;

    // Use this for initialization
    void Start () {
        playerCollider = GetComponent<PolygonCollider2D>();
        audioSource = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
        Vector2 moveAxis = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 moveDelta = moveAxis * movementSpeed * Time.deltaTime;
        
        if ( (bounds.leftScreenBounds.bounds.Intersects(playerCollider.bounds)))
        {
            transform.Translate(-0.1f, 0.0f, 0.0f);
        }
        else if (bounds.rightScreenBounds.bounds.Intersects(playerCollider.bounds))
        {
            transform.Translate(0.1f, 0.0f, 0.0f);
        }
        else if (bounds.topScreenBounds.bounds.Intersects(playerCollider.bounds))
        {
            transform.Translate(0.0f, -0.1f, 0.0f);
        }
        else if (bounds.bottomScreenBounds.bounds.Intersects(playerCollider.bounds))
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
