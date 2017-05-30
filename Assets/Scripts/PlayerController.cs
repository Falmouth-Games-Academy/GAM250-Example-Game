using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float movementSpeed = 2.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 moveAxis = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 moveDelta = moveAxis * movementSpeed * Time.deltaTime;
        transform.position += new Vector3(moveDelta.x, moveDelta.y, 0.0f);
	}
}
