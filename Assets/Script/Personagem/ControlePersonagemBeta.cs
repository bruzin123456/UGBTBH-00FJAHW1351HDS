using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
[NetworkSettings(channel=1,sendInterval=0f)]
public class ControlePersonagemBeta : NetworkBehaviour {
	private float vel = 5;
	[SyncVar] Vector2 pos = new Vector2(0,0);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (hasAuthority == true) {
			if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0) {
				transform.position = new Vector3 (transform.position.x + vel * Time.deltaTime * Input.GetAxis ("Horizontal"), transform.position.y + vel * Time.deltaTime * Input.GetAxis ("Vertical"), 0);
				CmdSetPos (transform.position);
			}
		} else {
			gameObject.transform.position = new Vector3 (pos.x, pos.y, gameObject.transform.position.z);
		}
	}


	[Command] void CmdSetPos(Vector2 position){
		pos = position;
	}
}
