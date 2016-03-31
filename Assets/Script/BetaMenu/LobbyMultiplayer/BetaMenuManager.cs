using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
public class BetaMenuManager : MonoBehaviour {
	public static BetaMenuManager unico;
	public BetaMenuManager(){
		unico = this;
	}
	// Uso Interno \\
	private Text text;
	// Pegar do Editor//
	public string[] cenas = new string[1];
	public Text[] PlayerNField = new Text [2];
	public InputField IP;
	public GameObject startGameButton;
	public GameObject disconnectButton;
	public GameObject returnToMenuButton;
	public GameObject hostButton;
	public GameObject JoinButton;
	public GameObject ipField;
	public GameObject ipText;
	public Dropdown sceneSelector;

	void Start(){
		ControleNetwork.unico = GameObject.Find ("NetworkManager").GetComponent<ControleNetwork> ();
	}

	void Update(){
		if (ControleNetwork.unico.PlayerNumber == 0 && ControleNetwork.unico.numPlayers == ControleNetwork.unico.maxPlayers) 	startGameButton.SetActive (true);
		else startGameButton.SetActive (false);
	}
	//Funções//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
	public void Host() {
		ControleNetwork.unico.IniciarServidor(16000);
		sceneSelector.gameObject.SetActive (true);
		foreach (string cena in cenas) {
			sceneSelector.options.Add (new UnityEngine.UI.Dropdown.OptionData () { text = (cena) });
		}
		sceneSelector.value = 1;
		sceneSelector.value = 0;
	}

	public void Join(){
		ControleNetwork.unico.ConectarServidor (IP.text, 16000);
	}

	public void StartGame(){
		ControleNetwork.unico.ServerChangeScene (cenas [sceneSelector.value]);
	}

	public void Disconnect(){
		if (ControleNetwork.unico.PlayerNumber == 1) {
			ControleNetwork.unico.StopClient();
		
		}
		if (ControleNetwork.unico.PlayerNumber == 0) {
			ControleNetwork.unico.StopHost();
		
		}
		NetworkServer.Reset ();
		SceneManager.LoadScene ("MenuBetaTeste", LoadSceneMode.Single);
	}

	public void ToMainMenu(){
		SceneManager.LoadScene ("FundoMenu", LoadSceneMode.Single);
	}

	public void HideJoinHost(){
		ipField.SetActive (false);
		hostButton.SetActive (false);
		JoinButton.SetActive (false);
		ipText.SetActive (false);
		returnToMenuButton.SetActive (false);
		returnToMenuButton.SetActive (false);
		disconnectButton.SetActive (true);
	}
}
