using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
[NetworkSettings(channel=0)]
public class PlayerManag : NetworkLobbyPlayer {
	[SyncVar] public string PlayerName;
	void Start(){
		if (isLocalPlayer && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "MenuBetaTeste" ) {
			CmdSetName (GameObject.Find ("Main Camera").GetComponent<BetaMenuManager> ().Name.text);
		}
	}
	void Update () {
		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "MenuBetaTeste") {
			GameObject.Find ("Main Camera").GetComponent<BetaMenuManager> ().PlayerNField [slot].text = PlayerName;
		}
	}


	// CallBacks lobbyPlayer \\
	public override void OnClientEnterLobby() {
		
	}
	// Funções Chamadas Na Rede... \\

	[Command] void CmdSetName(string playerN){
		PlayerName = playerN;
	}
}
