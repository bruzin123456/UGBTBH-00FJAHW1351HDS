using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ControleNetwork : NetworkLobbyManager {
	public static ControleNetwork unico;
	public int PlayerNumber;

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


}
