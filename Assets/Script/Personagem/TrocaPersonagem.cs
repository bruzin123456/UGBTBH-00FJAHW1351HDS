using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[NetworkSettings(channel = 0, sendInterval = 0.1f)]
public class TrocaPersonagem : NetworkBehaviour {
	[SyncVar] bool Trocar;
	public GameObject balaoP;
	private GameObject balao;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if (hasAuthority) {
			if (Input.GetButtonDown ("SwitchPlayer")) {
				if (balao == null) {
					balao = Instantiate (balaoP);
					CmdReadyTroca ();
				} else {
					CmdCancelTroca ();
					Destroy (balao);
				}
			}
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
