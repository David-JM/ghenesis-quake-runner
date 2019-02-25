using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Commons;
using UI;

namespace GameCore
{
    public class PointController : MonoBehaviour
    {
        [SerializeField] private GameObject secondBonus;

        /**
        Metodo que es invocado cuando el collider del jugador colisione con un colider del tipo trigger, 
        en este caso es usado para detectar cuando el jugador haya logrado salir del edificio,
        siguiendo las indicaciones y rutas de evacuacion para ponerse a salvo y ganar la partida
        **/
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag.Equals(Config.TAG_PLAYER))
            {
                if (this.tag.Equals(Config.TAG_EXIT))
                {
                    Debug.Log("Salio del mayor");
                    GameObject.FindWithTag(Config.TAG_PLAYER).GetComponent<PlayerMovementControl>().setEnableFps(false);
                    GameObject.FindWithTag(Config.TAG_GAME_CONTROLLER).GetComponent<GameController>().EvaluateVictory();
                }
                else
                {
                    ProgressTime.getInstance().CountingTime = false;
                    secondBonus.SetActive(true);
                    Debug.Log("Entro a punto de control");
                    Invoke("AddSeconds", 3);
                }
            }
        }

        private void AddSeconds()
        {
            secondBonus.SetActive(false);
            ProgressTime.getInstance().CountingTime = true;
            ProgressTime.getInstance().TimeSeconds += Config.SECOND_BONUS;
            Destroy(gameObject);
        }
    }
}