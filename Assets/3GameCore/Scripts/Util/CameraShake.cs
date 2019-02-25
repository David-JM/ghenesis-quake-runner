using UnityEngine;
using System.Collections;

namespace GameCore
{
	/**
 	* Clase con las funciones y atributos para la simulacion del terremoto desde la perspectiva de la camara
 	**/
	public class CameraShake : MonoBehaviour
	{
		// Transform of the camera to shake. Grabs the gameObject's transform if null.
		public Transform camTransform;
		
		// How long the object should shake for.
		public float shakeDuration = 0f;
		
		// Amplitude of the shake. A larger value shakes the camera harder.
		public float shakeAmount = 0.7f;
		public float decreaseFactor = 1.0f;
		
		Vector3 originalPos;
		
		// Metodo que se lanza antes de la inicializacion
		void Awake()
		{
			if (camTransform == null)
			{
				camTransform = GetComponent(typeof(Transform)) as Transform;
			}
		}
		
		// Metodo que es invocado cuando el componete cambia de estado inactivo a estado activo
		void OnEnable()
		{
			originalPos = camTransform.localPosition;
		}

		// Update is called once per frame
		void Update()
		{
			if (shakeDuration > 0)
			{
				camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;				
				shakeDuration -= Time.deltaTime * decreaseFactor;
			}
			else
			{
				shakeDuration = 0f;
				camTransform.localPosition = originalPos;
			}
		}
	}
}