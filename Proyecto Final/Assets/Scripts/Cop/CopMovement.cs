using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopMovement : MonoBehaviour {

	public float speed;

	// Movement Boundaries
	public float lBound;
	public float rBound;
	public float uBound;
	public float dBound;

	public int[] movementOrder;
	private int currentMovement;

	private Vector2 initialPosition;

	private void move(Vector2 direction, int arraySize){
		int nextPosition = (currentMovement + 1) % arraySize;
		int nextMove = movementOrder[nextPosition]; // Hard Code Next Move;

		GetComponent<Rigidbody2D>().velocity = direction * speed;

		switch (movementOrder [currentMovement]) {
		case 0:
			if ((transform.position.y - initialPosition.y) > dBound) {
				nextMove = currentMovement;
			}
			break;
		case 1:
			if ((transform.position.y - initialPosition.y) < uBound) {
				nextMove = currentMovement;
			}
			break;
		case 2:
			if ((transform.position.x - initialPosition.x) > lBound) {
				nextMove = currentMovement;
			}
			break;
		case 3:
			if ((transform.position.x - initialPosition.x) < rBound) {
				nextMove = currentMovement;
			}
			break;
		}

		currentMovement = nextMove;
	}

	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
		currentMovement = 0;
	}
	
	// Update is called once per frame
	void Update () {

		/* 0 -> Down
		 * 1 -> Up
		 * 2 -> Left
		 * 3 -> Rigth
		 */ 
		int arraySize = movementOrder.Length;
		Vector2 direction = new Vector2 (0, 0);

		switch (movementOrder [currentMovement]) {
		case 0:
			direction.x = 0;
			direction.y = -1;
			move (direction, arraySize);
			break;

		case 1:
			direction.x = 0;
			direction.y = 1;
			move (direction, arraySize);
			break;

		case 2:
			direction.x = -1;
			direction.y = 0;
			move (direction, arraySize);
			break;

		case 3:
			direction.x = 1;
			direction.y = 0;
			move (direction, arraySize);
			break;
		}

	}
}
