using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPerfil : MonoBehaviour {
	// Pegar Do Edtior \\
	public Text PlayerName;
	public Text TimePlayed;
	public Text Progress;
	public InputField NameInput;


	void Start () {
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

}


