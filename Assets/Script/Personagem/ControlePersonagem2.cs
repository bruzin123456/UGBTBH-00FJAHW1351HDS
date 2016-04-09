using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[NetworkSettings(channel=1,sendInterval=0.1f)]
public class ControlePersonagem2 : ControleBase {
	private Rigidbody2D rig2d;
	public Transform Verificaterrain;
	private float vel = 5f;
	private float fPulo = 1000f;
	public bool contatoterrain;
	public bool FacingRightLocal = true;

	[SyncVar] bool FacingRightServer = true;

	void Start () {
		lerpint = 0.6f;
		rig2d = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update é chamado frame por frame
	void Update(){
		FacingSide (); // Vira o Boneco para o lado certo...
		if (hasAuthority == true)
			Pulo(); // Pula
		
	}
	void FixedUpdate () {
		if (hasAuthority == true) // Ve se você tem autoridade sobre o personagem para movelo
			Movimentacao ();  // Verifica Input e Mover Personagem
		else
			InterpRefresh ();  // Atualiza para a posição que o servidor enviar
	}

	//Movimentação!!
	void Movimentacao() {
				//  Anda 
			Vector2 AxisInput = new Vector2(Input.GetAxis ("Horizontal"),0);
			if (AxisInput != Vector2.zero) {
				rig2d.position += (AxisInput * vel * Time.fixedDeltaTime);
			if (AxisInput.x > 0)   ////// Atribui a direção que o boneco está virado
				FacingRightLocal = true;
			else
				FacingRightLocal = false;
				}
			//Pega a Posição do personagem e envia para o server (host)
			CmdSetPos (rig2d.position);
		}


	void Pulo(){
		contatoterrain = Physics2D.Linecast (transform.position, Verificaterrain.position, 1 << LayerMask.NameToLayer ("terrain"));
		if (Input.GetButtonDown ("Jump") && contatoterrain) {
			rig2d.AddForce (Vector2.up * fPulo);
		}
	}


	///////////  Atualiza o Lado Que O Personagem esta virado Na rede
	void FacingSide(){
		if (hasAuthority == true) {
			if (FacingRightServer != FacingRightLocal)
				CmdSetFacing (FacingRightLocal);
		} else
			FacingRightLocal = FacingRightServer;
		////////////////  Aplica A Rotação /////////////////////
		if (FacingRightLocal == true)
			transform.eulerAngles = new Vector2 (0,0);
		else transform.eulerAngles = new Vector2 (0,180);

	}
	/////////// Muda a Variavel de Lado No Host /////////////////////////////////
	[Command(channel = 0)] void CmdSetFacing(bool facingright){
		FacingRightServer = facingright;
	}

	/////////////////////////////////////////////////////////////////////////////
}