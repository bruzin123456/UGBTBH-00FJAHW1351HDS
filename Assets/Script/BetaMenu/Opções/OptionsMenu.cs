using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour {
	public void ToMainMenu(){
		SceneManager.LoadScene ("MainMenu",LoadSceneMode.Additive);
		SceneManager.UnloadScene ("Opções");
	}


}
