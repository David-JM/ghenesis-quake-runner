using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Commons;
using GameCore;

namespace UI
{
    /**
 	* Clase con los atributos y metodos para el control del tiempo limite para estar a salvo del terremoto
 	**/
    public class ProgressTime : MonoBehaviour
    {
        private Image imgProgressTime;

        [SerializeField] private Text timeText;

        private float timeAmt, timeSeconds;
        private bool countingTime;

        public float TimeAmt { get; set; }
        public float TimeSeconds { get; set; }
        public bool CountingTime { get; set; }

        private static ProgressTime instance;
        public static ProgressTime getInstance()
        {
            return instance;
        }

        // Use this for initialization
        void Start()
        {
            instance = this;
            imgProgressTime = this.GetComponent<Image>();
        }

        // Update is called once per frame
        void Update()
        {
            if (CountingTime == true)
            {
                if (TimeSeconds > 0)
                {
                    TimeSeconds -= Time.deltaTime;
                    imgProgressTime.fillAmount = TimeSeconds / TimeAmt;
                    timeText.text = TimeSeconds.ToString("f");
                }
                else
                {
                    GameObject.FindWithTag(Config.TAG_PLAYER).GetComponent<PlayerMovementControl>().setEnableFps(false);
                    GameStats.getInstance().ShowPanel(Config.PNL_GAME_OVER);
                }
            }
        }
    }
}