using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[NetworkSettings(channel=1,sendInterval=0f)]
public class ControlePersonagemBeta : ControleBase {
	
	float vel = 5f;

	void Start () {
		lerpint = 0.4f;
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
				InterpRefresh ();

			}
		}
		
	}
	void Update () {
		
	}
}
