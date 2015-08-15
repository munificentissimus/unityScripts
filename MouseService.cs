using UnityEngine;
using System.Collections;

public class MouseService : MonoBehaviour {

	public GameController gameController;
	private Vector3 posicaoInicial;
	private Vector3 posicaoFinal;
	private string direcao = "";

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnMouseDown(){
		direcao = "";
		posicaoInicial = Input.mousePosition;
	}

	void OnMouseUp(){
		posicaoFinal = Input.mousePosition;

		direcao = DirecaoService.GetDirecao(this.posicaoInicial, this.posicaoFinal);

		gameController.SetDirecao(this.direcao);

		Debug.Log("Direcao: " + this.direcao);
//		Debug.Log("tendenciaHorizontal: " + tendenciaHorizontal);
//		Debug.Log("tendenciaVertical: " + tendenciaVertical);
	}
}
