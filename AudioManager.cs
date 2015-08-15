using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {

	//Uma lista de clipes musicais que podem ser executados a qualquer momento pelo indice;
	[SerializeField]
	private List<AudioClip> Musicas = new List<AudioClip>();

	//Fonte de audio a ser cacheado
	private AudioSource _musica = null;

	//Musica atualmente sendo tocada
	private int _clipeAtual = 0;

	private static AudioManager _instance = null;
	public static AudioManager instance 
	{
		get
		{
			if (_instance == null )
			{
				_instance = (AudioManager) FindObjectOfType(typeof(AudioManager));
			}

			return _instance;
		}
	}

	void Awake()
	{
		//Faz com que o gerenciador de audio sobreviva as trocas de cenas
		DontDestroyOnLoad(gameObject);

		//Cria uma copia da fonte de audio para manipulaçao
		_musica = GetComponent<AudioSource>();

		if (_musica)
		{
			//Evita que ela se inicia com o inicio da cena
			_musica.playOnAwake = false;
			_musica.volume = 0;
			_musica.Stop();
		}
	}

	//Executa um clipe musical da lista de musicas
	public void TocarMusica(int clipe, float graduacao	)
	{
		//Se nao existe um AudioResource interrompe a execuçao (return)
		if (!_musica) return;

		//Se a lista de muiscas nao existe nao existem clipes na faixa solicitada ou a faixa nao foi definida interrompe (return)
		if (Musicas==null || Musicas.Count <= clipe || Musicas[clipe]==null) return;

		//Se foi solicitado o clipe atual e este jah esta sendo executado nao faz nada, interrompe (return)
		if (_clipeAtual == clipe && _musica.isPlaying) return;

		//Seleciona o clipe atual como o clipe a tocar
		_clipeAtual = clipe;

		StartCoroutine( IniciarGradualmente( clipe, graduacao ));
	}

	public void PararMusica(float graduacao)
	{
		//Se nao existe fonte de audio nao ha o que parar
		if (!_musica) return;

		// Atribui -1 para o clipe atual ( o mesmo que dizer que nao ha nenhuma musica tocando)
		_clipeAtual = -1;

		//Inicia a coroutine de parar gradualmente
		StartCoroutine(PararGradualmente( graduacao ));
	}

	private IEnumerator PararGradualmente(float graduacao)
	{
		if (graduacao<1.0f) graduacao = 1.0f;

		if (_musica)
		{
			_musica.volume = 1.0f;

			// Criar uma variavel para ser o temporizador
			float temporizador = 0.0f;
			
			// Enquanto temporizador estiver no tempo de inicio gradual
			while(temporizador < graduacao)
			{
				//Incrementa o temporizador
				temporizador += Time.deltaTime;
				
				//Calcula o fator atual do volume (aumento gradual)	
				_musica.volume = 1.0f - (temporizador / graduacao);
				
				yield return null;
			}

			//Para totalmente a execucao do clipe
			_musica.volume = 0f;
			_musica.Stop();
		}	

	}

	private IEnumerator IniciarGradualmente(int clipe, float graduacao)
	{
		//Verifica se o graduacao eh menor que 0.1f (minimo)
		if (graduacao <= 0.1f) graduacao = 0.1f;

		//Testa se existe fonte de audio
		if (_musica)
		{
			//Interrompe qualquer musica que estiver sendo tocada
			_musica.volume = 0.0f;
			_musica.Stop();

			//Alterar o clipe para o solicitado e comeca a tocar
			_musica.clip = Musicas[clipe];
			_musica.Play();

			// Criar uma variavel para ser o temporizador
			float temporizador = 0.0f;

			// Enquanto temporizador estiver no tempo de inicio gradual
			while(temporizador <= graduacao)
			{
				//Incrementa o temporizador
				temporizador += Time.deltaTime;

				//Calcula o fator atual do volume (aumento gradual)	
				_musica.volume = temporizador / graduacao;

				yield return null;
			}

			//O volume estah agora no seu maximo
			_musica.volume = 1.0f;
		}
	}


}
