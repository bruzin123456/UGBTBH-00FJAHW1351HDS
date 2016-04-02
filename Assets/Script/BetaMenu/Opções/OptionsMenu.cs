using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {
	// Pegar do Editor \\
	public Dropdown screenMode;
	public Dropdown language;
	public Text mainMenu;
	public Text apply;
	public Text resolution;
	public Text fullScreen;



	public void ToMainMenu(){
		SceneManager.LoadScene ("MainMenu",LoadSceneMode.Additive);
		SceneManager.UnloadScene ("Opções");
	}
	void Start(){
		language.value = Perfil.language;
		SetLanguague ();
	}

	public void ChangeLanguage(){
		Perfil.language = language.value;
	}

	void SetLanguague(){
		if (Perfil.language == 1) {
			BaseMenuText languageT = new PortugueseMenuText();
			mainMenu.text = languageT.returnToMenu;
			apply.text = languageT.apply;
			resolution.text = languageT.screenResolution;
			fullScreen.text = languageT.screenMode;
			screenMode.options [0].text = languageT.fullScreen;
			screenMode.options [1].text = languageT.window;
			screenMode.value = 0;
			screenMode.value = 1;
			if (Screen.fullScreen == true)
				screenMode.value = 0;
			else
				screenMode.value = 1;
		}
	}



}
