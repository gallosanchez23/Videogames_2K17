using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VorcoInit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject[] Vorco = GameObject.FindGameObjectsWithTag ("Player");
		Vorco [0].transform.position = new Vector2 (-4.0f, 5.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
