using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//Vidas restantes
	private int _vidas = 3;
	public int vidas{get{return _vidas;}}

	//Pontuacao atual do jogador
	private int _pontuacaoAtual = 0;
	public int pontuacaoAtual {
		get {
			return _pontuacaoAtual;
		}
	}

	private int _nivelAtual = 0;
	public int nivelAtual{get{return _nivelAtual;}}

	//Singleton - Apenas um GameManager deve existir
	private static GameManager _instance = null;
	public static GameManager instance
	{
		get
		{
			if (_instance==null)
			{
				_instance = (GameManager) FindObjectOfType(typeof(GameManager));
			}

			return _instance;
		}
	}

	//Ao inicializar
	void Awake(){
		//Faz com que o objeto sobreviva as mudanças de cena
		DontDestroyOnLoad(gameObject);

		//Inicializar o estado do jogo
		_vidas = 3;
		_pontuacaoAtual = 0;
		_nivelAtual = 0;
	}
}
