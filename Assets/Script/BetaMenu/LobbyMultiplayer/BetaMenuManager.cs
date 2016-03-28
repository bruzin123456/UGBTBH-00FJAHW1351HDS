using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
public class BetaMenuManager : MonoBehaviour {
	public static BetaMenuManager unico;
	public BetaMenuManager(){
		unico = this;
	}

	// Pegar do Editor//
	public Text[] PlayerNField = new Text [2];
	public InputField IP;


	//Funções//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
	public void Host() {
		ControleNetwork.unico.IniciarServidor(16000);
	}
	public void Join(){
		ControleNetwork.unico.ConectarServidor (IP.text, 16000);
	}
}
