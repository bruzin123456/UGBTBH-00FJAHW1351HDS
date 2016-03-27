using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	
	public void QuitGame(){
		Application.Quit();
	}

	public void Coop(){
		SceneManager.LoadScene ("MenuBetaTeste", LoadSceneMode.Single);
	}
}
