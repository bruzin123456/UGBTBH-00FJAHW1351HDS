using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Resolutions : MonoBehaviour {
	public Dropdown ResolutionDrop;
	private Text text;
	Resolution[] resolutions;
	void Start () {
		ResolutionDrop = gameObject.GetComponent<Dropdown> ();
		ResolutionDrop.options.Clear ();
		resolutions = Screen.resolutions;
		foreach (Resolution res in resolutions) {
			ResolutionDrop.options.Add (new UnityEngine.UI.Dropdown.OptionData () {text=(res.width+"X"+res.height) });
		}
		ResolutionDrop.value = 1;
		ResolutionDrop.value = 0;
		for (int i = 0; i < resolutions.Length; i++) {
			if (resolutions [i].width == Screen.width && resolutions [i].height == Screen.height)
				ResolutionDrop.value = i;
		}


	}
		
	public void ApplyResolution(){
		if (ResolutionDrop.value != Perfil.Resolution) {
			Perfil.Resolution = ResolutionDrop.value;
			Screen.SetResolution (resolutions [ResolutionDrop.value].width, resolutions [ResolutionDrop.value].height, Screen.fullScreen);
		}
	}
	}
