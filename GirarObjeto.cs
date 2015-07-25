	using UnityEngine;
	using System.Collections;

/**
* Script utilizado para rotacionar um objeto nos eixos y e y
 */
public class GirarObjeto : MonoBehaviour {

	//Fica true enquanto o objeto esta rodando
	private bool rodando = false;

	//Contador de graus do giro
	private float contador = 0.0f;

	//Obtem o componente de transformaçao do objeto
	private Transform myTransform = null;

	//Objeto afetado por esse script
	public GameObject myGameObject;

	//Direçao do movimento de rotacao
	public Vector3 direcao = new Vector3(0,0,0);

	//Velocidade em graus do movimento de rotacao - deve ser numero multiplo do angulo de movimento
	public float velocidade = 0.0f;

	//Angulo de rotacao do movimento
	public float angulo = 0.0f;


	void Start () {
		//Se nao tiver sido atribuido um objeto para o script, seleciona o objeto na qual o script esta anexado
		if (myGameObject == null) {
			myGameObject = gameObject;
		}

		//Obtem o objeto de transformacao do objeto
		myTransform = myGameObject.transform;
	}
	
	void FixedUpdate () {
		//Se o objeto estiver em movimento de rotacao (rodando)
		if (rodando){
			//Incrementa o contador de graus ja realizados
			contador += velocidade;

			//Movimenta o objeto na direcao definida na quantidade de graus definido como velocidade
			myTransform.RotateAround(myTransform.position, direcao, velocidade );

			//Se o contador alcancar o angulo desejado para de rodar
			if ( contador >= angulo){
				//Para de rodar
				rodando = false;
				//Inicializa o contador
				contador = 0;
			}
		}
	}
	
	//Funcao de testes utilizando o mouse + raycasting
	void OnMouseDown(){
		// girarParaEsquerda();
		// girarParaDireita();
		// girarParaCima();
		girarParaBaixo ();
	}

	//Faz com que o objeto gire para a esquerda
	public void girarParaEsquerda(){
		if (!rodando) {		
			direcao = new Vector3 (0, 1, 0);
			rodando = true;
		}
	}

	//Faz com que o objeto gire para a direita 
	public void girarParaDireita(){
		if (!rodando) {		
			direcao = new Vector3 (0, -1, 0);
			rodando = true;
		}
	}

	//Faz com que o objeto gire para a cima
	public void girarParaCima(){
		if (!rodando) {		
			direcao = new Vector3 (1, 0, 0);
			rodando = true;
		}
	}

	//Faz com que o objeto gire para a baixo 
	public void girarParaBaixo(){
		if (!rodando) {		
			direcao = new Vector3 (-1, 0, 0);
			rodando = true;
		}
	}
}