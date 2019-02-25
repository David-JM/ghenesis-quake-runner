using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using Commons;
using UI;

namespace GameCore
{
    /**
 	* Clase principal con las funciones y atributos para gestionar el movimiento del jugador en primera persona y en dispositivos moviles
 	**/
    public class PlayerMovementControl : MonoBehaviour
    {
        private FixedJoystick move;
        private FixedButton jump;
        private FixedTouchField touch;
        private RigidbodyFirstPersonController fps;
        private GameObject controlls;

        // Use this for initialization
        void Start()
        {
            fps = GetComponent<RigidbodyFirstPersonController>();

            controlls = GameObject.FindWithTag(Config.TAG_CONTROLS);
            move = controlls.GetComponentInChildren<FixedJoystick>();
            jump = controlls.GetComponentInChildren<FixedButton>();
            touch = controlls.GetComponentInChildren<FixedTouchField>();
        }

        // Update is called once per frame
        void Update()
        {
            fps.RunAxis = move.inputVector;
            fps.JumpAxis = jump.Pressed;
            fps.mouseLook.LookAxis = touch.TouchDist;
        }

        public void setEnableFps(bool enable)
        {
            fps.enabled = enable;
        }
    }
}