using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerManag : NetworkBehaviour {
	[SyncVar] public string Player1Name;
	[SyncVar] public string Player2Name;

	public static PlayerManag unico;

	public PlayerManag(){
		unico = this;
	}
	void Awake(){
		if (isServer)
			gameObject.name = "Player1";
	}

	void Start () {
		Debug.Log ("Started");
		//Player1Name = GameObject.Find ("Main Camera").GetComponent<BetaMenuManager> ().Name.text;
		SetNames ();
	}
	
	// Update is called once per frame
	void Update () {
		SetNames ();
	}


	public void SetNames(){
		if (isServer) 		
			CmdPlayer1Name (GameObject.Find ("Main Camera").GetComponent<BetaMenuManager> ().Name.text);
		
		else
			CmdPlayer2Name (GameObject.Find ("Main Camera").GetComponent<BetaMenuManager> ().Name.text);
			
	
	}
	[Command] void CmdPlayer1Name(string playerN){
		Player1Name = playerN;
		RpcSetNames ();
	}
	[Command] void CmdPlayer2Name(string playerN){
		Player2Name = playerN;
		RpcSetNames ();
	}
	[ClientRpc] void RpcSetNames(){
		GameObject.Find ("Main Camera").GetComponent<BetaMenuManager> ().Player2N.text = Player2Name;
		GameObject.Find ("Main Camera").GetComponent<BetaMenuManager> ().Player1N.text = Player1Name;
	}

}
