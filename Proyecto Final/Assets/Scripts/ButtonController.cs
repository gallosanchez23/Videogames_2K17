using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

	public void IniciarJuego(){
		SceneManager.LoadScene("Cell Level");
	}

	public void MenuPrincipal(){
		SceneManager.LoadScene("MainMenu");
	}

	public void VerCreditos(){
		SceneManager.LoadScene("Creditos");
	}

	public void Instrucciones(){
		SceneManager.LoadScene("Instrucciones");
	}

	public void Salir(){
		Application.Quit ();
	}
}
