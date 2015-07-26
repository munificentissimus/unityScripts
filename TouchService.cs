using UnityEngine;
using System.Collections;

public class TouchService : MonoBehaviour {

	public GameController gameController;
	private Vector3 posicaoInicial;
	private Vector3 posicaoFinal;
	private string direcao = "";

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

		foreach(Touch toque in Input.touches){
			if ( toque.phase == TouchPhase.Began){
				this.OnTouchBegan(toque);
			}

			if ( toque.phase == TouchPhase.Ended){
				this.OnTouchEnded(toque);
			}
		}
	}

	public void OnTouchBegan(Touch _toque){
		direcao = "";
		posicaoInicial = _toque.position;
	}

	public void OnTouchEnded(Touch _toque){
		posicaoFinal = _toque.position;

		direcao = DirecaoService.GetDirecao(this.posicaoInicial, this.posicaoFinal);

		gameController.SetDirecao(this.direcao);

		Debug.Log("Direcao: " + this.direcao);
		//		Debug.Log("tendenciaHorizontal: " + tendenciaHorizontal);
		//		Debug.Log("tendenciaVertical: " + tendenciaVertical);
	}
}
