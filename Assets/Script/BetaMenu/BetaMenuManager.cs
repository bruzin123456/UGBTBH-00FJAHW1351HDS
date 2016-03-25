using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
public class BetaMenuManager : MonoBehaviour {
	private string ip;
	string PlayerName = "Player";
	string Player1Name;
	string Player2Name;



	// Pegar do Editor//
	public InputField Name;
	public InputField IP;
	public Text Player1N;
	public Text Player2N;

	//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
	//Funções//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
	public void Host() {
		ControleNetwork.unico.IniciarServidor(16000);
		Player1Name = PlayerName;
		Player1N.text = Player1Name;


	}
	public void Join(){
		ControleNetwork.unico.ConectarServidor (ip, 16000);
	}
	// Set Var//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
	public void SetPlayerName (){
		PlayerName = Name.text;
		Debug.Log (PlayerName);
	}
	public void Setip (){
		ip = IP.text;
		Debug.Log (ip);
	}


	//Chamadas Da Rede //
	public void OnStartHost(){
		Debug.Log ("Teste");
	}
}
