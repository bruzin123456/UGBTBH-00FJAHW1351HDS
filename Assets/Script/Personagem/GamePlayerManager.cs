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
		SpawnPoint (objeto);
	}


	// Teste Spawn Point
	void SpawnPoint(GameObject objetop){
		ControleBase controle = objetop.GetComponent<ControleBase> ();
		Vector2 posicao;
		////////////////////
		if (objetop.name == "Player1") {
			posicao = GameObject.Find ("SpawnP1").transform.position;		
		} else {
			posicao = GameObject.Find ("SpawnP2").transform.position;
		}
		////////////////////
		controle.pos = posicao;
		objetop.transform.position = new Vector3 (posicao.x, posicao.y, gameObject.transform.position.z);
		controle.RpcSpawnPos (posicao);
		controle.Paused = false;
	}
		
}
