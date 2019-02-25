using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Commons;

namespace UI
{
    /**
   * Clase util con funciones communes para la gestion de la interfaz de usuario
   **/
    public class UICommonFunctions : MonoBehaviour
    {
        private AudioSource soundfx;

        // Use this for initialization
        void Start()
        {
            soundfx = this.GetComponent<AudioSource>();
        }

        // Metodo que carga la escena enviada como parametro
        public void ChangeEscene(int indexEscene)
        {
            SceneManager.LoadScene(indexEscene);
        }

        // Metodo que retorna el Menu principal del juego
        public void Salir()
        {
            Application.Quit();
        }

        // Metodo que reproduce un efecto de sonido de la interfaz
        public void PlaySound()
        {
            soundfx.Play();
        }
    }
}