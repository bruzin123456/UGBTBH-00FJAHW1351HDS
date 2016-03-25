using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerManag : NetworkBehaviour {
	 public string PlayerName;
	public string Player2Name;

	// Use this for initialization
	void Start () {
		PlayerName = GameObject.Find ("Main Camera").GetComponent<BetaMenuManager> ().Name.text;
		Debug.Log ("Testando" + PlayerName);
		//SetNames ();
	}
	
	// Update is called once per frame
	void Update () {
		//SetNames ();
	}
	public void SetNames(){
		if (isLocalPlayer && ControleNetwork.unico.PlayerNumber == 1)
			RpcPlayer1Name();
		if (isLocalPlayer && ControleNetwork.unico.PlayerNumber == 2)
			CmdPlayer2Name(PlayerName);
	}
	[Command] void CmdPlayer2Name(string playerN){
		Player2Name = playerN;
		RpcPlayer2Name (Player2Name);
	}
	[ClientRpc] void RpcPlayer2Name(string playerN){
		GameObject.Find ("Main Camera").GetComponent<BetaMenuManager> ().Player2N.text = playerN;
	}
	[ClientRpc] void RpcPlayer1Name(){
		GameObject.Find ("Main Camera").GetComponent<BetaMenuManager> ().Player1N.text = PlayerName;
	}
}
