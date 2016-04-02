using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
[NetworkSettings(channel=0,sendInterval=0f)]
public class ControlePersonagemBeta : NetworkBehaviour {
	private float vel = 5;
	[SyncVar] Vector2 pos;
	[SyncVar] bool Paused = true;


	void Start () {
		if (isServer) 
			SpawnPoint ();	
	}
	

	void Update () {
		if (Paused == false) {
			if (hasAuthority == true) {
				if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0) {
					transform.position = new Vector3 (transform.position.x + vel * Time.deltaTime * Input.GetAxis ("Horizontal"), transform.position.y + vel * Time.deltaTime * Input.GetAxis ("Vertical"), 0);
					CmdSetPos (transform.position);
				}
			} else {
				gameObject.transform.position = new Vector3 (pos.x, pos.y, gameObject.transform.position.z);
			}
		}
	}


	void SpawnPoint(){
		Vector2 posicao;
		if (gameObject.name == "Player1") {
			posicao = GameObject.Find ("SpawnP1").transform.position;		
		} else {
			posicao = GameObject.Find ("SpawnP2").transform.position;
		}
		pos = posicao;
		RpcSpawnPos (posicao);
		Paused = false;
	}


	[Command] void CmdSetPos(Vector2 position){
		pos = position;
	}


	[ClientRpc] void RpcSpawnPos(Vector2 position){
		gameObject.transform.position = new Vector3 (position.x, position.y, gameObject.transform.position.z);
	}
}
