using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
[NetworkSettings(channel=0)]
public class PlayerManag : NetworkLobbyPlayer {
	[SyncVar] public string PlayerName;



	void Start(){
		if (isLocalPlayer && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "MenuBetaTeste" ) {
			CmdSetName (BetaMenuManager.unico.Name.text);
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
