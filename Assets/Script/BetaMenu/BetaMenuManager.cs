using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BetaMenuManager : MonoBehaviour {
	private const string typeName = "MeuJoJo";
	private const string gameName = "TesteBeta";
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
		Network.InitializeServer(1, 16000, !Network.HavePublicAddress());
		Player1Name = PlayerName;
		Player1N.text = Player1Name;

	}
	public void Join(){
		Network.Connect (ip, 16000);
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
	void SetPlayer2Name (string name){
		Player2Name = name;
	}
	void SetPlayer1Name (string name){
		Player1Name = name;
	}

	//Chamadas Da Rede //
	void OnServerInitialized()	{
		Debug.Log("Server Initializied");
	}
	void OnPlayerConnected(NetworkPlayer player) {
		Debug.Log(" connected from " + player.ipAddress + ":" + player.port);
		Player2N.text = "Conectado";
	}
}
