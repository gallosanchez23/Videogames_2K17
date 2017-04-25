using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCollider : MonoBehaviour{

	private int keys_counter;
  public Text keys_count_text;

  private int character_gate_counter = 0;
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
    //keys_count_text.text = "Llaves: " + keys_counter.ToString();
  }

  void Start(){
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
    keys_counter = 0;
    SetCountText();
  }

  void OnTriggerEnter2D(Collider2D other){
    if(other.gameObject.CompareTag("Key")){
      other.gameObject.SetActive(false);
      keys_counter++;
      SetCountText();
    }

    else if(other.gameObject.CompareTag("MainBtnT")){
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
      other.gameObject.SetActive(false);
      green_btn_f[0].SetActive(true);
    }

    else if(other.gameObject.CompareTag("BlueBtnT")){
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
			keys_counter--;
			other.gameObject.SetActive (false);
		} else {
			print ("Consigue la llave!!!");
		}
	}
  }
}
