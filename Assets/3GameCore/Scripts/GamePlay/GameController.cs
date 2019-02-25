using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Commons;
using UI;

namespace GameCore
{
    /**
 	* Clase principal con las funciones y atributos para el control del juego
 	**/
    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject clock;
        [SerializeField] private GameObject[] escenariosPiso1;
        [SerializeField] private GameObject[] escenariosPiso2;
        [SerializeField] private GameObject[] escenariosPiso3;

        private AudioSource music;
        private Level nivel;

        // Metodo que se lanza antes de la inicializacion
        void Awake()
        {
            // Valida si se debe cargar o no el tutorial
            if (PlayerPrefs.GetInt(Config.TUTORIAL_DONE) == 0)
                PlayerPrefs.SetInt(Config.TUTORIAL_DONE, 1);

            switch (PlayerPrefs.GetInt(Config.LEVEL))
            {
                case 1:
                    nivel = new Level(Config.MAGNITUD_LV1, Config.SECONDS_LV1, escenariosPiso1);
                    break;
                case 2:
                    nivel = new Level(Config.MAGNITUD_LV2, Config.SECONDS_LV2, escenariosPiso2);
                    break;
                case 3:
                    nivel = new Level(Config.MAGNITUD_LV3, Config.SECONDS_LV3, escenariosPiso3);
                    break;
                default:
                    break;
            }
        }

        // Use this for initialization
        void Start()
        {
            GameObject spawn = nivel.Escenarios[Random.Range(0, 4)];
            GameObject.Instantiate(player, spawn.transform.position, spawn.transform.rotation);

            music = this.GetComponent<AudioSource>();
            Invoke("StartEarthQuake", 3);
            InvokeRepeating("Shake", 3, 15);
        }

        // Metodo que da inicio a la emulacion del terremoto
        private void StartEarthQuake()
        {
            clock.SetActive(true);
            ProgressTime progressTime = clock.GetComponentInChildren<ProgressTime>();
            progressTime.TimeAmt = nivel.Seconds;
            progressTime.TimeSeconds = nivel.Seconds;
            progressTime.CountingTime = true;
            music.Play();
        }

        private void Shake()
        {
            CameraShake shake = Camera.main.GetComponent<CameraShake>();
            shake.enabled = true;
            shake.shakeDuration = 5;
            shake.shakeAmount = nivel.Magnitud / 10;
        }

        // Metodo que evalua cuando el jugador sube de nivel
        public void EvaluateVictory()
        {
            PlayerPrefs.SetInt(Config.CONT_WINS, PlayerPrefs.GetInt(Config.CONT_WINS) + 1);
            if (PlayerPrefs.GetInt(Config.CONT_WINS) > 1)
            {
                PlayerPrefs.SetInt(Config.CONT_WINS, 0);
                PlayerPrefs.SetInt(Config.LEVEL, PlayerPrefs.GetInt(Config.LEVEL) + 1);
                GameStats.getInstance().ShowPanel(Config.PNL_LEVEL_UP);
            }
            else
            {
                GameStats.getInstance().ShowPanel(Config.PNL_WIN);
            }
        }
    }
}
