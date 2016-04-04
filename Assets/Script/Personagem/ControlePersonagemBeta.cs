 using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
[NetworkSettings(channel=1,sendInterval=0f)]
public class ControlePersonagemBeta : NetworkBehaviour {
    float lerpint = 0.4f;
	float vel = 5f;
	[SyncVar]public Vector2 pos;
	[SyncVar] public bool Paused = true;


	void Start () {
	}

	void FixedUpdate(){
		
		Rigidbody2D rig2d = gameObject.GetComponent<Rigidbody2D> ();
		if (Paused == false) {
			if (hasAuthority == true) {
				Vector2 AxisInput = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
				if (AxisInput.magnitude > 1)
					AxisInput = AxisInput.normalized;
				if (AxisInput != Vector2.zero) {
					rig2d.position = (rig2d.position + AxisInput*(vel*Time.fixedDeltaTime));
				}
				CmdSetPos (rig2d.position);
				//////////////////////////////////////////////////////
			} else {		
				rig2d.position = Vector2.Lerp (rig2d.position, new Vector2 (pos.x, pos.y), lerpint);

			}
		}
		
	}
	void Update () {
		
	}
		
	[Command] void CmdSetPos(Vector2 position){
		pos = position;
	}


	[ClientRpc(channel = 1)] public void RpcSpawnPos(Vector2 position){
		gameObject.transform.position = new Vector3 (position.x, position.y, gameObject.transform.position.z);
	}
}
