using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GamePlayerManager : NetworkBehaviour {
	public GameObject FadaTeste;
	// Use this for initialization
	void Start () {
		if (hasAuthority) {
			CmdSpawnCharacter (ControleNetwork.unico.PlayerNumber);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	[Command] void CmdSpawnCharacter(int playnumb){
		GameObject objeto = Instantiate (FadaTeste);
		objeto.name = ("Player" + (playnumb + 1));
		NetworkServer.SpawnWithClientAuthority (objeto, gameObject);
	}
}
