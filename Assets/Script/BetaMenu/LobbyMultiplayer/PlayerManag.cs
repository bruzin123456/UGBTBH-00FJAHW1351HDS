using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
[NetworkSettings(channel=0)]
public class PlayerManag : NetworkLobbyPlayer {
	[SyncVar] public string PlayerName;

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}

	void Start(){
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
