using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[NetworkSettings(channel=1,sendInterval=0f)]
public class ControleBase : NetworkBehaviour {
	
	protected float lerpint = 0.4f;
	[SyncVar] public Vector2 pos;
	[SyncVar] public bool Paused = true;

	[Command] public void CmdSetPos(Vector2 position){
		pos = position;
	}

	/// Spawn Position \\\
	[ClientRpc(channel = 1)] public void RpcSpawnPos(Vector2 position){
		gameObject.transform.position = new Vector3 (position.x, position.y, gameObject.transform.position.z);
	}



	protected void InterpRefresh(){
		Rigidbody2D rigbody2d = gameObject.GetComponent<Rigidbody2D> ();
		rigbody2d.position = Vector2.Lerp (rigbody2d.position, new Vector2 (pos.x, pos.y), lerpint);
	}
}

