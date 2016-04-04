 using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
[NetworkSettings(channel=1,sendInterval=0f)]
public class ControlePersonagemBeta : NetworkBehaviour {
	float distanceUntLerp = 0f;
    float lerpint = 0.4f;
	float vel = 5f;
	[SyncVar] Vector2 pos;
	[SyncVar] bool Paused = true;


	void Start () {
		if (isServer) 
			SpawnPoint ();	
	}
	

	void Update () {
		if (Paused == false) {
			if (hasAuthority == true) {
				Vector3 AxisInput = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"),0f);
				if (AxisInput.magnitude > 1)
					AxisInput = AxisInput.normalized;
				if (AxisInput != Vector3.zero) {
					transform.position = (transform.position + AxisInput*(vel*Time.deltaTime));
					CmdSetPos (transform.position);
				}
			} else {
				if (Vector2.Distance (transform.position, pos) > distanceUntLerp) {  // Se distancia maior que "distanceUntLerp" usar metodo lerp para interpolar a posição do personagem, se não usar move towards
					gameObject.transform.position = Vector3.Lerp (gameObject.transform.position, new Vector3 (pos.x, pos.y, gameObject.transform.position.z), lerpint);
				} else {
					transform.position = Vector3.MoveTowards (transform.position, new Vector3 (pos.x, pos.y, gameObject.transform.position.z), vel * Time.deltaTime); 
				}
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
		gameObject.transform.position = new Vector3 (posicao.x, posicao.y, gameObject.transform.position.z);
		RpcSpawnPos (posicao);
		Paused = false;
	}


	[Command] void CmdSetPos(Vector2 position){
		pos = position;
	}


	[ClientRpc(channel = 0)] void RpcSpawnPos(Vector2 position){
		gameObject.transform.position = new Vector3 (position.x, position.y, gameObject.transform.position.z);
	}
}
