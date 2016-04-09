using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GamePlayerManager : NetworkBehaviour {
	public GameObject FadaTeste;
	public GameObject ArmaduraTeste;

	// Use this for initialization
	void Start () {
		if (hasAuthority) {
			ControleNetwork.JogadoresGamePlayerManag [ControleNetwork.PlayerNumber] = this;
			CmdSpawnCharacter ();
		} else {
			ControleNetwork.JogadoresGamePlayerManag [ControleNetwork.OtherPlayerNumber ()] = this;
		}
	
	}


	// \\\\\\\\\\\\\\ Função Para Chamar Spawn Character No Server \\\\\\\\\\\\\\\\\\
	[Command] void CmdSpawnCharacter(){
		SpawnCharacter();
	}
		

	// Spawn Character
	public void SpawnCharacter(){
		int playnumb;
		GameObject objeto;
		PlayerManag jogador;
		/////////// Verifica Qual o Player Manager deste Objeto \\\\\
		playnumb = ControleNetwork.PlayerNumberThisObject(hasAuthority);
		jogador = ControleNetwork.JogadoresPlayerManag[playnumb];
		/////////////// Pega a bool armadura para verificar oq ele vai spawna \\\\\\\\\
		if (jogador.armadura)
			objeto = ArmaduraTeste;
		else
			objeto = FadaTeste;
		/////////////////Spawna o Jogador e Seta a posição Para o Spawn Position \\\\\\\\\
		objeto = Instantiate (objeto);
		objeto.name = ("Player" + (playnumb + 1));
		NetworkServer.SpawnWithClientAuthority (objeto, gameObject);
		ControleNetwork.Jogadores [playnumb] = objeto;
		SpawnPoint (objeto);
	}

	//////////////// Spawn Point//\\\\\\\\\\\\\\
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
