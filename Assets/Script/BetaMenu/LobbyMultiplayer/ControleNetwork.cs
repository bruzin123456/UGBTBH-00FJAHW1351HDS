using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class ControleNetwork : NetworkLobbyManager {
	public static ControleNetwork unico;
	public static PlayerManag[] JogadoresPlayerManag = new PlayerManag[2];
	public static GamePlayerManager[] JogadoresGamePlayerManag = new GamePlayerManager[2]; 
	public static GameObject[] Jogadores = new GameObject[2];
	public static int PlayerNumber = 10;

	public ControleNetwork(){
		unico = this;
	}
	
	public void IniciarServidor (int port){
		PlayerNumber = 0;
		networkPort = port;
		StartHost ();
	}
	public void ConectarServidor(string ip, int port){
		PlayerNumber = 1;
		networkAddress = ip;
		networkPort = port;
		StartClient ();
	}

	public string GetSceneName(){
		return networkSceneName;
	}



	// Call Backs \\\\\\\\\\\\\\\\\\\\\
	public override void OnLobbyStartHost(){
		Debug.Log ("ServidorIniciado");

	}
	public override void OnLobbyServerConnect(NetworkConnection conn){
		Debug.Log ("ConectadoJogador: "+conn.address);
	}
	public override void OnLobbyClientConnect(NetworkConnection conn) {
		BetaMenuManager.unico.HideJoinHost ();
	}

	///////////////////////////// Funções Auxiliares \\\\\\\\\\\\\\\\\\\\\\
	/// 
	/// 
	//////////////// Numero Do Jogador do Jogador que não é voce \\\\\\\\
	public static int OtherPlayerNumber(){
		if (ControleNetwork.PlayerNumber == 1)
			return 0;
		else
			return 1;
	}
	// //      Numer do jogador Associado ao objeto \\\\\\\\\
	public static int PlayerNumberThisObject(bool authority){
		if (authority)
			return PlayerNumber;
		else
			return OtherPlayerNumber ();
	}
		
		

}
