using UnityEngine;
using System.Collections;

public class SceneManagerSplash	: MonoBehaviour {
	
	void Start () {
		Invoke("IrParaMenu",3.0f);

		Debug.Log(AudioManager.instance);
		if (AudioManager.instance) AudioManager.instance.TocarMusica(0 , 5.0f); 

	}
	
	private void IrParaMenu(){
		Application.LoadLevel("Menu");
	}
}
