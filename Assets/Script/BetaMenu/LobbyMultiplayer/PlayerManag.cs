using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
[NetworkSettings(channel=0)]
public class PlayerManag : NetworkLobbyPlayer {
	[SyncVar] public string PlayerName;
	[SyncVar] public bool armadura;
	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}

	void Start(){
		//////// Marca como o seu Player Manager ou o do parceiro
		if (hasAuthority)
			ControleNetwork.meuPlayerManag = this;
		else
			ControleNetwork.parceiroPlayerManag = this;
		/////// Set Para Fada ou Armadura
		if (isServer) {
			if (hasAuthority)
				armadura = true;
			else
				armadura = !ControleNetwork.meuPlayerManag.armadura;
		}
		////////// Pega Nome Do Jogaador
		if (isLocalPlayer && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "MenuBetaTeste" ) {
			CmdSetName (Perfil.PlayerName);
		}
	}
	void Update () {
		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "MenuBetaTeste") {
			BetaMenuManager.unico.PlayerNField [slot].text = PlayerName;
		}

	}
		

	// Funções Chamadas Na Rede... \\

	[Command] void CmdSetName(string playerN){
		PlayerName = playerN;
	}
}
