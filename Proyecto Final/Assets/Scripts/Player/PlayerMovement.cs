using UnityEngine;
using System.Collections;

// PlayerScript requires the GameObject to have a Rigidbody2D component

[RequireComponent (typeof (Rigidbody2D))]

public class PlayerMovement : MonoBehaviour {


	public float playerSpeed = 4f;
	private Vector2 sPosition;

	void Start () {
		sPosition = transform.position;
	}

	void FixedUpdate () {
		Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		GetComponent<Rigidbody2D>().velocity=targetVelocity * playerSpeed;

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("FOV")) {
			transform.position = sPosition;
			print ("Hi");
		}
			
	}
}