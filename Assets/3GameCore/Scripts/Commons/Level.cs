using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Commons
{
    /**
 	* Clase que contiene los atributos que definen los niveles del juego
 	**/
    public class Level
    {
        private float magnitud;
        private float seconds;
        private GameObject[] escenarios;

        public float Magnitud { get; set; }
        public float Seconds { get; set; }
        public GameObject[] Escenarios { get; set; }

        // constructor de la clase
        public Level(float magnitud, float seconds, GameObject[] escenarios)
        {
            Magnitud = magnitud;
            Seconds = seconds;
            Escenarios = escenarios;
        }
    }
}
