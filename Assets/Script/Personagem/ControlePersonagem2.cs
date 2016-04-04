using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
[NetworkSettings(channel=1,sendInterval=0f)]

public class ControlePersonagem2 : NetworkBehaviour {

	private float velocidade = 5;
	[SyncVar] bool contatoterrain;
	float fPulo = 300;
	[SyncVar] public Transform Verificaterrain;
	[SyncVar] Vector2 pos = new Vector2(0,0);
	[SyncVar] bool Paused = true;

	// Use this for initialization
	void Start () {
		if (isServer) 
			SpawnPoint ();	
	}
		
	//Movimentação!!
	void Movimentacao() {
			// Ve se você tem autoridade sobre o personagem para movelo
		if (hasAuthority == true) {

			// atribui o valor do Verificaterrain esta encostado em 1 layer com o nome de terrain
			contatoterrain = Physics2D.Linecast(transform.position, Verificaterrain.position, 1 << LayerMask.NameToLayer("terrain"));
			//Anda para a direita
			if (Input.GetAxisRaw ("Horizontal") > 0) {
				transform.Translate (Vector2.right * velocidade * Time.deltaTime);
				transform.eulerAngles = new Vector2 (0, 0);

				//Pega a Posição do personagem e envia para o server (host)
				CmdSetPos (transform.position);
			}

			//Anda para a esquerda
			if (Input.GetAxisRaw ("Horizontal") < 0) {
				transform.Translate (Vector2.right * velocidade * Time.deltaTime);
				transform.eulerAngles = new Vector2 (0, 180);
				//Pega a Posição do personagem e envia para o server (host)
				CmdSetPos (transform.position);
			}

			//Pular
			if (Input.GetButtonDown("Jump") && contatoterrain) {
				GetComponent<Rigidbody2D>().AddForce(transform.up * fPulo);
				//Pega a Posição do personagem e envia para o server (host)
				CmdSetPos (transform.position);
			}
		}else {
			// Não sei!
				gameObject.transform.position = new Vector3 (pos.x, pos.y, gameObject.transform.position.z);
			}
	}
	
	// Update is called once per frame
	void Update () {
			Movimentacao();
	}

	[Command] void CmdSetPos(Vector2 position){
		pos = position;
	}


	/// Spawn Position \\\
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

	[ClientRpc(channel = 0)] void RpcSpawnPos(Vector2 position){
		gameObject.transform.position = new Vector3 (position.x, position.y, gameObject.transform.position.z);
	}
}
