using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    /**
 	* Clase que con las funciones y atributos para realizar el control del boton de controles izquierdo (usado para mover el personaje)
 	**/
    public class FixedTouchField : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [HideInInspector]
        public Vector2 TouchDist;
        [HideInInspector]
        public Vector2 PointerOld;
        [HideInInspector]
        protected int PointerId;
        [HideInInspector]
        public bool Pressed;

        // Update is called once per frame
        void Update()
        {
            if (Pressed)
            {
                if (PointerId >= 0 && PointerId < Input.touches.Length)
                {
                    TouchDist = Input.touches[PointerId].position - PointerOld;
                    PointerOld = Input.touches[PointerId].position;
                }
                else
                {
                    TouchDist = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - PointerOld;
                    PointerOld = Input.mousePosition;
                }
            }
            else
            {
                TouchDist = new Vector2();
            }
        }

        // Metodo que se lanza cuando un puntero presione sobre el boton
        public void OnPointerDown(PointerEventData eventData)
        {
            Pressed = true;
            PointerId = eventData.pointerId;
            PointerOld = eventData.position;
        }

        // Metodo que se lanza cuando se levante el puntero del boton
        public void OnPointerUp(PointerEventData eventData)
        {
            Pressed = false;
        }

    }
}