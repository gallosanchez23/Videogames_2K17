using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class random : MonoBehaviour {

	int count;
	public Text countText;
	public AudioClip impact;
	// Use this for initialization
	void Start () {
		count = 5;
		countText.text = "x " + count.ToString();
		Vector2 pos = new Vector2 (Random.Range (0, 8), Random.Range (0, 3f));
		transform.position = pos;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Bullet"))
		{
			AudioSource.PlayClipAtPoint(impact, this.transform.position);
			count--; //score
			countText.text = "x " + count.ToString();
			Destroy (other.gameObject);
			Vector2 pos = new Vector2 (Random.Range (0, 9), Random.Range (0, 3f));
			transform.position = pos;
			if(count == 0) // win condition
			{
				Application.LoadLevel("Outer Level");
			}
		}
	}

}
