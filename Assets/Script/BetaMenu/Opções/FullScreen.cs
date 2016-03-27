using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FullScreen : MonoBehaviour {
	public Dropdown FullscreenDrop;
	// Use this for initialization
	void Start () {
		FullscreenDrop = gameObject.GetComponent<Dropdown> ();
		if (Screen.fullScreen)
			FullscreenDrop.value = 0;
		else
			FullscreenDrop.value = 1;
	}


	public void SetScreenMode(){
		if (Screen.fullScreen) {
			if (FullscreenDrop.value == 0)
				return;
			else {
				Screen.fullScreen = !Screen.fullScreen;
				return;
			}

		} else {
			if (FullscreenDrop.value == 1)
				return;
			else {
				Screen.fullScreen = !Screen.fullScreen;
				return;
		}
	}
}
}

