using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[NetworkSettings(channel = 0, sendInterval = 0.1f)]
public class TrocaPersonagem : NetworkBehaviour {
	[SyncVar] bool Trocar=false;
	public GameObject balaoP;
	private GameObject balao;


	void OnDestroy(){
		if (balao != null)
			Destroy (balao);
	}
		
	void Update () {
		if (hasAuthority) {
			// Pega Comando e Decide Ação \\
			if (Input.GetButtonDown ("SwitchPlayer")) {
				if (balao == null) {
					balao = Instantiate (balaoP);
					CmdReadyTroca ();
				} else {
					CmdCancelTroca ();
					Destroy (balao);
				}
			}
				// Verifica Se Ambos querem trocar \\
			if (isServer) { 
				if (Trocar && ControleNetwork.Jogadores [ControleNetwork.OtherPlayerNumber ()].GetComponent<TrocaPersonagem> ().Trocar) {
					Trocar = false;
					ControleNetwork.SwapCharacter ();
				}
			}
			////// Fim Authority \\\\\\\\\\\\\\\
		} else {
			if (Trocar && balao == null)
				balao = Instantiate (balaoP);
			else if (!Trocar && balao != null)
				Destroy (balao);
		}
		if (balao != null)
			balao.transform.position = (transform.position + new Vector3 (1f, 1f, transform.position.y));
		}


	[Command]void CmdReadyTroca (){
    	Trocar = true;
	}
	[Command] void CmdCancelTroca(){
		Trocar = false;
	}
		
}
