using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
[NetworkSettings(channel=1,sendInterval=0f)]

public class ControlePersonagem2 : NetworkBehaviour {

	private float velocidade = 5;
	[SyncVar] Vector2 pos = new Vector2(0,0);

	// Use this for initialization
	void Start () {
	
	}
		
	//Movimentação!!
	void Movimentacao() {
			// Ve se você tem autoridade sobre o personagem para movelo
		if (hasAuthority == true) {
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
}
