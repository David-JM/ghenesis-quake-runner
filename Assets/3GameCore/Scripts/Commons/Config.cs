using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Commons
{
    /**
 	* Clase con las constantes y variables communes para todo el juego
 	**/
    public class Config
    {
        //Tags
        public const string TAG_CONTROLS = "Controls";
        public const string TAG_EXIT = "Exit";
        public const string TAG_PLAYER = "Player";
        public const string TAG_GAME_CONTROLLER = "GameController";

        //Parametros Animator Controllers
        public const string HIDDEN = "hidden";

        //Indices de las escenas o niveles del juego
        public const int ESCENA_INTRO = 0;
        public const int ESCENA_MENU = 1;
        public const int ESCENA_CREDITOS = 2;
        public const int ESCENA_BUILDING_MAP = 3;

        // Paneles del GameStats
        public const int PNL_WIN = 1;
        public const int PNL_LEVEL_UP = 2;
        public const int PNL_GAME_OVER = 3;
        public const int PNL_HELP = 4;

        //Player prefs keys
        public const string PLAYER_NAME = "playerName";
        public const string CONT_WINS = "ContWins";
        public const string TUTORIAL_DONE = "tutorialDone";
        public const string LEVEL = "level";
        public const int LEVEL_DEFAULT = 1;

        /* Configuracion de niveles */
        public const int TOTAL_NIVELES = 3;
        public const float MAGNITUD_LV1 = 1;
        public const float SECONDS_LV1 = 41;
        public const float MAGNITUD_LV2 = 5;
        public const float SECONDS_LV2 = 31;
        public const float MAGNITUD_LV3 = 10;
        public const float SECONDS_LV3 = 21;
        public const float SECOND_BONUS = 10;

    }
}