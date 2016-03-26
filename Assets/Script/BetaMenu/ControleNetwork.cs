using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ControleNetwork : NetworkManager {
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



	// Call Backs \\\\\\\\\\\\\\\\\\\\\
	public override void OnStartHost(){
		Debug.Log ("ServidorIniciado");

	}
	public override void OnServerConnect(NetworkConnection conn){
		Debug.Log ("ConectadoJogador: "+conn.address);
		if (conn.address == "localServer") {
			//PlayerManag.Player [0].GetName();
		}
	

		
	}


}
