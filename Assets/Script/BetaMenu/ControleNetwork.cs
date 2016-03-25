﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ControleNetwork : NetworkManager {
	public static ControleNetwork unico;
	public int PlayerNumber;
	public GameObject playermanager;

	public ControleNetwork(){
		unico = this;
	}
	
	public void IniciarServidor (int port){
		PlayerNumber = 1;
		networkPort = port;
		StartHost ();
	}
	public void ConectarServidor(string ip, int port){
		PlayerNumber = 2;
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
			playermanager = Instantiate (playermanager);
			NetworkServer.Spawn (playermanager);
		}
			if (conn.address != "localServer" && conn.address != "localClient") {
				Debug.Log ("Set Authority");
				PlayerManag.unico.gameObject.GetComponent<NetworkIdentity> ().AssignClientAuthority (conn);
			}
				

		
	}


}
