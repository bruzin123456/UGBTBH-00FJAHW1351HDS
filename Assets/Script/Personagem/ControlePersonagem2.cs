using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
[NetworkSettings(channel=1,sendInterval=0f)]

public class ControlePersonagem2 : NetworkBehaviour {

	float vel = 5f;
	bool contatoterrain;
	float fPulo = 50;
	public Transform Verificaterrain;
	[SyncVar] public Vector2 pos;
	[SyncVar] public bool Paused = true;

	void Start () {
	}
	
	// Update é chamado frame por frame
	void Update () {
			Movimentacao();
	}

	//Movimentação!!
	void Movimentacao() {
		
			// Ve se você tem autoridade sobre o personagem para movelo
			if (hasAuthority == true) {
				//Pega a Posição do personagem e envia para o server (host)
				CmdSetPos (transform.position);

				// atribui o valor do Verificaterrain esta encostado em 1 layer com o nome de terrain
				contatoterrain = Physics2D.Linecast (transform.position, Verificaterrain.position, 1 << LayerMask.NameToLayer ("terrain"));
				//Anda para a direita
				if (Input.GetAxisRaw ("Horizontal") > 0) {
				transform.Translate (Vector2.right * vel * Time.deltaTime);
					transform.eulerAngles = new Vector2 (0, 0);
				}

				//Anda para a esquerda
				if (Input.GetAxisRaw ("Horizontal") < 0) {
				transform.Translate (Vector2.right * vel * Time.deltaTime);
					transform.eulerAngles = new Vector2 (0, 180);
				}

				//Pular
			if (Input.GetButtonDown ("Jump") && contatoterrain) {
					GetComponent<Rigidbody2D> ().AddForce (transform.up * fPulo);
				}
					
			} else {
				// Não sei!
				gameObject.transform.position = new Vector3 (pos.x, pos.y, gameObject.transform.position.z);
			}
		}
	

	[Command] void CmdSetPos(Vector2 position){
		pos = position;
	}
		
	/// Spawn Position \\\
	[ClientRpc(channel = 1)] public void RpcSpawnPos(Vector2 position){
		gameObject.transform.position = new Vector3 (position.x, position.y, gameObject.transform.position.z);
	}
}