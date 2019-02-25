using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Commons;
using GameCore;

namespace Util
{
	/**
 	* Clase con los atributos y metodos para el control de los eventos de animacion de la Intro del juego
 	**/
	public class AnimationEventsController : MonoBehaviour 
	{
		[SerializeField]private GameObject efecto;
		private AudioSource sound;

		// Metodo que se ejecuta al Inicio de la escena
		void Start() 
		{
			sound = GetComponent<AudioSource> ();
		}

		// Metodo que activa un efecto de sonido, es invocado como un animationEvent desde la animacion del Logo
		public void PlaySound(float initTime) 
		{
            sound.time = initTime;
			sound.Play ();
		}

		// Metodo que activa un objeto en particular, por ejemplo particulas, sprites, prefabs, etc
		public void ActivarObjeto() 
		{
			efecto.SetActive (true);
		}

		// Metodo que hace una simulacion visual de un terremoto
		public void ShakeCamera(float duration)
		{
            CameraShake shake = Camera.main.GetComponent<CameraShake>();
            shake.enabled = true;
            shake.shakeDuration = duration;
		}

		// Metodo que fija la propiedad Hide del animator controller
        public void hideEfect()
        {
            efecto.GetComponent<Animator>().SetBool("hide", true);
        }

		// Metodo que carga la siguiente escena al terminar la Intro
        public void LoadScene()
        {
            SceneManager.LoadScene(Config.ESCENA_MENU);
        }
	}
}