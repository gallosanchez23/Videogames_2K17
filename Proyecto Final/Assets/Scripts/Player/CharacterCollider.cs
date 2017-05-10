using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterCollider : MonoBehaviour{

	public AudioClip keySound;
	public AudioClip doorOpen;
	public AudioClip guardCollision;
	public AudioClip doorLocked;
	public AudioClip FX_button;

	private int keys_counter;
	public int playerLives;
	private int clues_counter;
	public Text keys_count_text;
	public Text lives_count_text;
	public Text clues_count_text;

	bool bMasterKey;

	private Vector2 sPosition;

	private int character_gate_counter = 0;
	private GameObject[] masterKey;
	private GameObject[] blue_gate;
	private GameObject[] green_gate;
	private GameObject[] red_gate;
	private GameObject[] character_gate;
	private GameObject[] key_gate;
	private GameObject[] evidence_gate;
	private GameObject[] blue_btn_t;
	private GameObject[] blue_btn_f;
	private GameObject[] green_btn_t;
	private GameObject[] green_btn_f;
	private GameObject[] red_btn_t;
	private GameObject[] red_btn_f;
	private GameObject[] main_btn_t;
	private GameObject[] main_btn_f;
	private GameObject[] true_btns = new GameObject[3];
	private GameObject[] false_objects = new GameObject[6];

	void SetCountText(){
		keys_count_text.text = "x " + keys_counter.ToString();
	}

	void SetLivesText(){
		lives_count_text.text = "x " + playerLives.ToString();
	}

	void SetCluesText(){
		clues_count_text.text = "x " + clues_counter.ToString ();
	}

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}

	void Start(){

		sPosition = transform.position;
		keys_counter = 0;
		clues_counter = 0;
		bMasterKey = false;

		masterKey = GameObject.FindGameObjectsWithTag ("Master Key");
		blue_gate = GameObject.FindGameObjectsWithTag("BlueGate");
		green_gate = GameObject.FindGameObjectsWithTag("GreenGate");
		red_gate = GameObject.FindGameObjectsWithTag("RedGate");
		character_gate = GameObject.FindGameObjectsWithTag("CharacterGate");
		key_gate = GameObject.FindGameObjectsWithTag("KeyGate");
		evidence_gate = GameObject.FindGameObjectsWithTag("EvidenceGate");
		blue_btn_t = GameObject.FindGameObjectsWithTag("BlueBtnT");
		blue_btn_f = GameObject.FindGameObjectsWithTag("BlueBtnF");
		green_btn_t = GameObject.FindGameObjectsWithTag("GreenBtnT");
		green_btn_f = GameObject.FindGameObjectsWithTag("GreenBtnF");
		red_btn_t = GameObject.FindGameObjectsWithTag("RedBtnT");
		red_btn_f = GameObject.FindGameObjectsWithTag("RedBtnF");
		main_btn_t = GameObject.FindGameObjectsWithTag("MainBtnT");
		main_btn_f = GameObject.FindGameObjectsWithTag("MainBtnF");
		true_btns[0] = blue_btn_t[0];
		true_btns[1] = green_btn_t[0];
		true_btns[2] = red_btn_t[0];
		false_objects[0] = blue_gate[0];
		false_objects[1] = green_gate[0];
		false_objects[2] = red_gate[0];
		false_objects[3] = blue_btn_f[0];
		false_objects[4] = green_btn_f[0];
		false_objects[5] = red_btn_f[0];

		masterKey [0].SetActive (bMasterKey);

		SetCountText();
		SetLivesText ();
		SetCluesText ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.CompareTag("Key")){
			AudioSource.PlayClipAtPoint(keySound, this.transform.position, 1.0f);
			other.gameObject.SetActive(false);
			keys_counter++;
			SetCountText();
		}

		else if(other.gameObject.CompareTag("MainBtnT")){
			AudioSource.PlayClipAtPoint(FX_button, this.transform.position, 1.0f);
			main_btn_t[0].SetActive(false);
			main_btn_f[0].SetActive(true);
			if(character_gate[0].activeSelf){
				character_gate[0].SetActive(false);
			}
			for(int i = 0; i < 3; i++){
			if(!true_btns[i].activeSelf){
				true_btns[i].SetActive(true);
				}
			}
			for(int i = 0; i < 6; i++){
				if(false_objects[i].activeSelf){
					false_objects[i].SetActive(false);
				}
			}
		}

		else if(other.gameObject.CompareTag("GreenBtnT")){
			AudioSource.PlayClipAtPoint(FX_button, this.transform.position, 1.0f);
			other.gameObject.SetActive(false);
			green_btn_f[0].SetActive(true);
		}

		else if(other.gameObject.CompareTag("BlueBtnT")){
			AudioSource.PlayClipAtPoint(FX_button, this.transform.position, 1.0f);
			if(!green_btn_t[0].activeSelf){
				other.gameObject.SetActive(false);
				blue_btn_f[0].SetActive(true);
			}
		else{
				other.gameObject.SetActive(false);
				blue_btn_f [0].SetActive (true);
				green_btn_t[0].SetActive(false);
				green_btn_f[0].SetActive(true);
				green_gate[0].SetActive(true);
				red_btn_t[0].SetActive(false);
				red_btn_f[0].SetActive(true);
				red_gate[0].SetActive(true);
				main_btn_t[0].SetActive(true);
				main_btn_f[0].SetActive(false);
			}
		}

		else if(other.gameObject.CompareTag("RedBtnT")){
			AudioSource.PlayClipAtPoint(FX_button, this.transform.position, 1.0f);
			if(!green_btn_t[0].activeSelf && !blue_btn_t[0].activeSelf){
				other.gameObject.SetActive(false);
				red_btn_f[0].SetActive(true);
				key_gate[0].SetActive(false);
				evidence_gate[0].SetActive(false);
			}
			else{
				other.gameObject.SetActive(false);
				red_btn_f[0].SetActive(true);
				blue_btn_t[0].SetActive(false);
				blue_btn_f[0].SetActive(true);
				blue_gate[0].SetActive(true);
				green_btn_t[0].SetActive(false);
				green_btn_f[0].SetActive(true);
				green_gate[0].SetActive(true);
				main_btn_t[0].SetActive(true);
				main_btn_f[0].SetActive(false);
			}
		}
		else if(other.gameObject.CompareTag("Door")){
			if (keys_counter > 0) {
				AudioSource.PlayClipAtPoint(doorOpen, this.transform.position, 1.0f);
				keys_counter--;
				SetCountText ();
				other.gameObject.SetActive (false);
			} else {
				AudioSource.PlayClipAtPoint(doorLocked, this.transform.position, 1.0f);
				print ("Consigue la llave!!!");
			}
		}

		else if(other.gameObject.CompareTag("Obj_MasterDoor")){
			if (bMasterKey) {
				AudioSource.PlayClipAtPoint(doorOpen, this.transform.position, 1.0f);
				bMasterKey = false;
				Destroy (other.gameObject);
			} else {
				AudioSource.PlayClipAtPoint(doorLocked, this.transform.position, 1.0f);
				print ("Consigue la llave maestra!!!");
			}
		}

		else if (other.gameObject.CompareTag ("FOV")) {
			transform.position = sPosition;
			playerLives--;
			SetLivesText ();
			AudioSource.PlayClipAtPoint(guardCollision, this.transform.position, 1.0f);

			if (playerLives < 0) {
				SceneManager.LoadScene ("Game Over");
			}
		}

		else if (other.gameObject.CompareTag ("Obj_MasterKey")) {
			AudioSource.PlayClipAtPoint(keySound, this.transform.position, 1.0f);
			bMasterKey = true;
			Destroy (other.gameObject);
			masterKey[0].SetActive (bMasterKey);
		}

		else if (other.gameObject.CompareTag ("Obj_Clue")) {
			clues_counter++;
			Destroy (other.gameObject);
			SetCluesText ();
		}

		else if (other.gameObject.CompareTag ("NextLevel")) {
			bMasterKey = false;
			masterKey[0].SetActive (bMasterKey);
			transform.position = new Vector2(-8.0f,5.0f);
			SceneManager.LoadScene("SceneMiniGame");
			SetCountText();
			SetLivesText ();
			SetCluesText ();
		}

		else if (other.gameObject.CompareTag ("Insider")) {
			if (clues_counter <= 1) {
				SceneManager.LoadScene ("BadEnding");
			}
			else if (clues_counter <= 3) {
				SceneManager.LoadScene ("NeutralEnding");
			}
			else if (clues_counter == 4) {
				SceneManager.LoadScene ("GoodEnding");
			}
		}
	}
}
