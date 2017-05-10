using UnityEngine;
using System.Collections;

// PlayerScript requires the GameObject to have a Rigidbody2D component

[RequireComponent (typeof (Rigidbody2D))]

public class PlayerMovement : MonoBehaviour {


	public float playerSpeed = 4f;

	void Start () {
	}

	void FixedUpdate () {
		Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		GetComponent<Rigidbody2D>().velocity=targetVelocity * playerSpeed;

		Quaternion target = Quaternion.Euler(0, 0, 0);
		transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 2.0f);
	}
}