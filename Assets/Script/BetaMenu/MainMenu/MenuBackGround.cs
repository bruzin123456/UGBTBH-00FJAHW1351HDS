using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuBackGround : MonoBehaviour {

	void Start () {
		SceneManager.LoadScene ("MainMenu", LoadSceneMode.Additive);
	}
}
