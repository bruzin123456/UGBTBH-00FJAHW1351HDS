using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
	// Pegar do Editor \\
	public Text perfilT;
	public Text optionsT;
	public Text quitGameT;

	public void QuitGame(){
		Application.Quit();
	}

	public void Coop(){
		SceneManager.LoadScene ("MenuBetaTeste", LoadSceneMode.Single);
	}
	public void Options(){
		SceneManager.LoadScene ("Opções", LoadSceneMode.Additive);
		SceneManager.UnloadScene("MainMenu");
	}

	public void PerfilB(){
		SceneManager.LoadScene ("Perfil", LoadSceneMode.Additive);
		SceneManager.UnloadScene("MainMenu");

	}

	void Start(){
		SetLanguage();
	}

	void SetLanguage(){
		if (Perfil.language == 1) {
			BaseMenuText languageT = new PortugueseMenuText ();
			perfilT.text = languageT.profile;
			optionsT.text = languageT.options;
			quitGameT.text = languageT.quitgame;
		}
	}
}
