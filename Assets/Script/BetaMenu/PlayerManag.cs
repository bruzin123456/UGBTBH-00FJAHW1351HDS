using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
[NetworkSettings(channel=1)]
public class PlayerManag : NetworkBehaviour {
	[SyncVar] public string PlayerName;
	[SyncVar] public int PlayerNumber = 0;







	void Start () {
		if (isLocalPlayer){
			CmdSetPlayerNumber (ControleNetwork.unico.PlayerNumber);
			GetName ();
		}
	}
	

	void Update () {
		GameObject.Find ("Main Camera").GetComponent<BetaMenuManager> ().PlayerNField [PlayerNumber].text = PlayerName;
	}

	public void GetName(){
		CmdSetName (GameObject.Find ("Main Camera").GetComponent<BetaMenuManager> ().Name.text);
	}

	// Funções Chamadas Na Rede... \\

	[Command] void CmdSetPlayerNumber(int n){
		PlayerNumber = n;
	}

	[Command] void CmdSetName(string playerN){
		PlayerName = playerN;

	}

}
