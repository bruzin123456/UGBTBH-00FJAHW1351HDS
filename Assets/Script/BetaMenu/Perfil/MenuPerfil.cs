using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPerfil : MonoBehaviour {

	// pegar do editor Set Language \\
	public Text nameT;
	public Text name2T;
	public Text timePlayedT;
	public Text pogroessT;
	public Text returnT;
	public Text saveT;
	public Text changeT;
	public Text confirmT;
	public Text cancelT;


	// Pegar Do Edtior \\
	public Text PlayerName;
	public Text TimePlayed;
	public Text Progress;
	public InputField NameInput;


	void Start () {
		SetLanguage ();
		PlayerName.text = Perfil.PlayerName;
		TimePlayed.text = (Perfil.MinutesPlayed+" min");
		Progress.text = (Perfil.Progress+"%");

	}

	public void ToMainMenu(){
		SceneManager.LoadScene ("MainMenu", LoadSceneMode.Additive);
		SceneManager.UnloadScene("Perfil");
	}

	public void ChangeNameOk(){
		if (NameInput.text != "") {
			GameObject.Find ("JanelaNome").SetActive(false);
			PlayerName.text = NameInput.text;
			Perfil.PlayerName = NameInput.text;
			NameInput.text = "";
		}
	}
	void SetLanguage(){
		if (Perfil.language == 1) {
			BaseMenuText languateT = new PortugueseMenuText ();
			nameT.text = languateT.name;
			name2T.text = languateT.name;
			timePlayedT.text = languateT.timePlayed;
			pogroessT.text = languateT.Progress;
			returnT.text = languateT.returnn;
			saveT.text = languateT.save;
			changeT.text = languateT.change;
			confirmT.text = languateT.confirm;
			cancelT.text = languateT.cancel;
		}
	}

}


