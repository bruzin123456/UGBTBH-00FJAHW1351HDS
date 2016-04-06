using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GamePlayerManager : NetworkBehaviour {
	public GameObject FadaTeste;
	public GameObject ArmaduraTeste;

	public bool armadura;
	// Use this for initialization
	void Start () {
		if (hasAuthority) {
			CmdSpawnCharacter (ControleNetwork.PlayerNumber);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	[Command] void CmdSpawnCharacter(int playnumb){
		GameObject objeto;
		PlayerManag jogador;
		/////////// Verifica Qual o Player Manager deste Objeto \\\\\
		if (hasAuthority)
			jogador = ControleNetwork.meuPlayerManag;
		else
			jogador = ControleNetwork.parceiroPlayerManag;
		/////////////// Pega a bool armadura para verificar oq ele vai spawna \\\\\\\\\
		if (jogador.armadura)
			objeto = ArmaduraTeste;
		else
			objeto = FadaTeste;
		/////////////////Spawna o Jogador e Seta a posição Para o Spawn Position \\\\\\\\\
		objeto = Instantiate (objeto);
		objeto.name = ("Player" + (playnumb + 1));
		NetworkServer.SpawnWithClientAuthority (objeto, gameObject);
		SpawnPoint (objeto);
	}


	// Teste Spawn Point
	void SpawnPoint(GameObject objetop){
		ControleBase controle = objetop.GetComponent<ControleBase> ();
		Vector2 posicao;
		////////////////////
		if (objetop.name == "Player1") {
			posicao = GameObject.Find ("SpawnP1").transform.position;		
		} else {
			posicao = GameObject.Find ("SpawnP2").transform.position;
		}
		////////////////////
		controle.pos = posicao;
		objetop.transform.position = new Vector3 (posicao.x, posicao.y, gameObject.transform.position.z);
		controle.RpcSpawnPos (posicao);
		controle.Paused = false;
	}
		
}
