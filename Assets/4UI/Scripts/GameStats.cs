using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Commons;

namespace UI
{
    /**
 	* Clase con los atributos y metodos para el control de la interfaz in Game
 	**/
    public class GameStats : MonoBehaviour
    {
        [SerializeField] private GameObject controlls;
        [SerializeField] private GameObject pnlOptions;
        [SerializeField] private GameObject pnlClock;
        [SerializeField] private GameObject infoPlayer;
        [SerializeField] private GameObject pnlGameOver;
        [SerializeField] private GameObject pnlWin;
        [SerializeField] private GameObject pnlLevelUp;
        [SerializeField] private GameObject pnlHelp;

        private static GameStats instance;
        public static GameStats getInstance()
        {
            return instance;
        }

        // Use this for initialization
        void Start()
        {
            instance = this;
            
            Text[] playerData = infoPlayer.GetComponentsInChildren<Text>();
            playerData[0].text = PlayerPrefs.GetString(Config.PLAYER_NAME);
            playerData[1].text = "Lv." + PlayerPrefs.GetInt(Config.LEVEL).ToString();
        }

        // Metodo que lanza el panel enviado como parametro  al finalizar el juego
        public void ShowPanel(int panel)
        {
            HideElementsUI();
            switch (panel)
            {
                case Config.PNL_WIN:
                    pnlWin.SetActive(true);
                    break;
                case Config.PNL_LEVEL_UP:
                    pnlLevelUp.SetActive(true);
                    break;
                case Config.PNL_GAME_OVER:
                    pnlGameOver.SetActive(true);
                    break;
                case Config.PNL_HELP:
                    ProgressTime.getInstance().CountingTime = false;
                    pnlHelp.SetActive(true);
                    break;
                default:
                    ProgressTime.getInstance().CountingTime = true;
                    pnlOptions.SetActive(true);
                    pnlClock.SetActive(true);
                    infoPlayer.SetActive(true);
                    controlls.SetActive(true);
                    pnlHelp.SetActive(false);
                    break;
            }
        }

        // Metodo que oculta todos los elementos de la interfaz de usuario
        private void HideElementsUI()
        {
            pnlOptions.SetActive(false);
            pnlClock.SetActive(false);
            infoPlayer.SetActive(false);
            controlls.SetActive(false);
            pnlHelp.SetActive(false);
        }
    }
}
