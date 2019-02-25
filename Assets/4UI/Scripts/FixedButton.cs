using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    /**
 	* Clase que con las funciones y atributos para realizar el control del boton de controles derecho (usado para saltar)
 	**/
    public class FixedButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        [HideInInspector]
        public bool Pressed;

        // Metodo que se lanza cuando un puntero presione sobre el boton
        public void OnPointerDown(PointerEventData eventData)
        {
            Pressed = true;
        }

        // Metodo que se lanza cuando se levante el puntero del boton
        public void OnPointerUp(PointerEventData eventData)
        {
            Pressed = false;
        }
    }
}