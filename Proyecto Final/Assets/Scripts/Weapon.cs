using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour {

	public AudioClip FX_bullet;

	public float fFireRate = 0;
	public float fDamage = 10;
	public LayerMask toHit;

	Rigidbody2D clone;
	public Rigidbody2D bala;
	float speed = 0f;
	private int bullets;
	public Text countText;

	//float timeToFire = 0;
	Transform firePoint;


	public float barDisplay; //current progress
	public Vector2 pos = new Vector2(20,40);
	public Vector2 size = new Vector2(60,20);
	public Texture2D emptyTex;
	public Texture2D fullTex;

	void Start () {
		bullets = 10;
		countText.text = "x " + bullets.ToString();
	}

	void OnGUI() {
	         GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
	             GUI.Box(new Rect(0,0, size.x, size.y), emptyTex);

	             //draw the filled-in part:
	             GUI.BeginGroup(new Rect(0,0, size.x * barDisplay, size.y));
	                 GUI.Box(new Rect(0,0, size.x, size.y), fullTex);
	             GUI.EndGroup();
	         GUI.EndGroup();
	}

	void Shoot()
	{
		AudioSource.PlayClipAtPoint(FX_bullet, this.transform.position, 1.0f);
		Vector2 shooting = new Vector2 ((firePoint.position.x-transform.position.x), (firePoint.position.y-transform.position.y));

		clone = Instantiate (bala, transform.position, transform.rotation);

		clone.velocity = (speed*(shooting.normalized));

		Destroy (clone.gameObject, 3);


		//Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		//Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
		//RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePosition-firePointPosition, 100);
	}

	// Use this for initialization
	void Awake () {
		firePoint = transform.FindChild ("FirePoint");
		if (firePoint == null) {
			Debug.LogError ("No FirePoint; Check Object");
		}
	}

	void RotateLeft(){
		if(transform.eulerAngles.z > 1 ) transform.Rotate (Vector3.forward * -1);
	}

	void RotateRight()
	{
		if(transform.eulerAngles.z < 90) transform.Rotate (Vector3.forward * 1);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("space")) {
			
			speed += 0.1f;
			barDisplay = speed*.04f;
			print(speed);
			if (speed > 25)
				speed = 0;
		}
		if (Input.GetKeyUp ("space")) {
			Shoot ();

			speed = 0;
			bullets--;
			countText.text = "x " + bullets.ToString();
			if(bullets == 0) Application.LoadLevel("GameOver");
		}
		if (Input.GetKey ("down")) RotateLeft();
		if (Input.GetKey("up")) RotateRight();
		/*
		if (fFireRate == 0) {
			if (Input.GetButtonDown ("Fire1")) {
				Shoot ();
			}
		} else {
			if (Input.GetButtonDown ("Fire1") && Time.time > timeToFire) {
				timeToFire = Time.time - 1 / fFireRate;
				Shoot ();
			}
		}
		*/
	}

}
