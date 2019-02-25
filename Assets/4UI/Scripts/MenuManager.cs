using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Commons;

namespace UI
{
    /**
 	* Clase con los atributos y metodos para el control del Menu Principal del juego
 	**/
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject pnlPerfil;
        [SerializeField] private GameObject pnlMenu;
        [SerializeField] private GameObject pnlConfirm;
        [SerializeField] private GameObject errorMsg;
        [SerializeField] private Text[] playerData;
        [SerializeField] private GameObject[] radars;

        private AudioSource music;

        // Use this for initialization
        void Start()
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            /*
            Se inicializa en 0, debido a que es un contador que solo tiene efectos durante la ejecucion actual del juego
            con el fin de validar que el jugador haya ganado mas de 1 partida de forma consecutiva para poder subir de nivel
             */
            PlayerPrefs.SetInt(Config.CONT_WINS, 0);

            if (PlayerPrefs.GetString(Config.PLAYER_NAME).Length > 0)
            {
                pnlPerfil.SetActive(false);
                pnlMenu.SetActive(true);
                SetPLayerData();
            }

            music = this.GetComponents<AudioSource>()[1];
            InvokeRepeating("playMusic", 0, 137f);

            StartCoroutine(StartAnimationRadar());
        }

        // Metodo que reproduce la musica de fondo del juego
        private void playMusic()
        {
            music.volume = 0.05f;
            music.Play();
            StartCoroutine(addVolume());
        }

        // Corrutina que aumenta gradualmente el volumen de la musica de fondo
        IEnumerator addVolume()
        {
            yield return new WaitForSeconds(0.5f);
            music.volume += 0.05f;
            if (music.volume < 0.5f)
                StartCoroutine(addVolume());
        }

        // Corrutina que aumenta gradualmente el volumen de la musica de fondo
        IEnumerator StartAnimationRadar()
        {
            yield return new WaitForSeconds(2f);
            radars[0].SetActive(true);
            yield return new WaitForSeconds(1f);
            radars[1].SetActive(true);
            yield return new WaitForSeconds(3f);
            radars[2].SetActive(true);
            yield return new WaitForSeconds(2f);
            radars[3].SetActive(true);
            yield return new WaitForSeconds(2f);
            radars[4].SetActive(true);
        }

        // Metodo que crea un nuevo perfil de jugador
        public void CreatePerfil()
        {
            InputField name = pnlPerfil.GetComponentInChildren<InputField>();
            if (name.text == null || name.text == "")
                errorMsg.SetActive(true);
            else
            {
                SetDefaultValues(name.text);
                StartCoroutine(ActivarAnimaciones(pnlPerfil, pnlMenu, true));
                SetPLayerData();
                name.text = "";
            }
        }

        // Metodo usado para fijar los datos del jugador
        private void SetPLayerData()
        {
            //Nombre del jugador
            playerData[0].text = PlayerPrefs.GetString(Config.PLAYER_NAME);
            //Nivel del jugador
            playerData[1].text = "Lv." + PlayerPrefs.GetInt(Config.LEVEL).ToString();
        }

        // Metodo que fija los valores por defecto de un nuevo Perfil
        private void SetDefaultValues(string playerName)
        {
            PlayerPrefs.SetString(Config.PLAYER_NAME, playerName);
            PlayerPrefs.SetInt(Config.LEVEL, Config.LEVEL_DEFAULT);
            PlayerPrefs.SetInt(Config.TUTORIAL_DONE, 0);
        }

        // Metodo que oculta el mensaje de error al crear un nuevo perfil
        public void HideErrorMsg()
        {
            errorMsg.SetActive(false);
        }

        // Metodo que elimina el perfil actual con todo el progreso del jugador y lo redirige al menu para crear un nuevo perfil
        public void ResetPerfil()
        {
            SetDefaultValues("");
            StartCoroutine(ActivarAnimaciones(pnlPerfil, pnlConfirm, false));
        }

        // Metodo que lanza el mensaje de confirmacion para cambiar de perfil
        public void ShowConfirmChangePerfil()
        {
            pnlMenu.SetActive(false);
            pnlConfirm.SetActive(true);
        }

        // Metodo que cancela el reset del perfil
        public void CancelResetPerfil()
        {
            pnlConfirm.SetActive(false);
            pnlMenu.SetActive(true);
        }

        // Coorutina que activa la animaciones de los elementos del menu
        IEnumerator ActivarAnimaciones(GameObject pnl1, GameObject pnl2, bool hide)
        {
            Animator anim = pnl1.GetComponent<Animator>();
            anim.SetBool(Config.HIDDEN, hide);
            yield return new WaitForSeconds(1);
            pnl1.SetActive(!hide);
            pnl2.SetActive(hide);
        }
    }
}
