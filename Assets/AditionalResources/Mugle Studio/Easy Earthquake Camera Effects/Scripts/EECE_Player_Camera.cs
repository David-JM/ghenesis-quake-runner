///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	EECE_Player_Camera.cs
//	© Artem Goldov (Mugle Studio). All Rights Reserved.
//	http://www.mugle.ru
//
//	Description: "Easy Earthquake Camera Effects" - the simplest solution to create and control Earthquake Effect.
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Requires the GameObject to have a AudioSource component for AudioClip.
[RequireComponent(typeof(AudioSource))]


public class EECE_Player_Camera : MonoBehaviour {
        
    Vector3 orig_Pos; // Original camera position.

    [Header("Easy Earthquake Camera Effects v1.0", order = 1)]

    // Transform of the camera to shake. Grabs the gameObject's transform
    public Transform CameraObject;

    [Space(5)]

    [Header("Settings:", order = 2)]

    // How long (In Seconds).
    public float TimeShake = 0f;

    // Amplitude of the shake.
    public float AmountShake = 0.7f;

    public float DecreaseShake = 1.0f;

    public bool Infinite = false;

    [Space(5)]

    [Header("Shake Settings (In seconds):", order = 2)]

    public float TimeShakeFromHit = 3;

    [Space(5)]

    [Header("Sounds:", order = 2)]

    public AudioSource PlayerAudio;

    public AudioClip ShakeHit;

    public AudioClip InfiniteLoop;

    public float Volume = 1.0f; //Volume 0.0f - 1.0f


    void Awake()
    {
        PlayerAudio = GetComponent<AudioSource>();

        if (CameraObject != null)
        {

            CameraObject = CameraObject.GetComponent(typeof(Transform)) as Transform;

        }
        else
        {

            Debug.LogError("EECE_Player_Camera: Error! You must add the Camera object to the script.");

        }
    }


    void OnEnable()
    {
        if (CameraObject != null)
        {

            orig_Pos = CameraObject.localPosition;

        }
    }


    void Update()
    {
        if (CameraObject != null)
        {

            if (TimeShake > 0 || Infinite == true)
            {

                CameraObject.localEulerAngles = orig_Pos + Random.insideUnitSphere * AmountShake; // Shake effect on

                if (Infinite == false)
                { 

                TimeShake -= Time.deltaTime * DecreaseShake;

                }

            }
            else
            {

                TimeShake = 0f;
                CameraObject.localPosition = orig_Pos; // Shake effect off

            }
        }
    }


    public void ShakeHit_Sound() // Shake Hit sound
    {
        if (PlayerAudio.isPlaying == false)
        {
            PlayerAudio.PlayOneShot(ShakeHit, Volume);
        }
    }


    public void InfiniteLoop_Sound() // Infinite Loop sound
    {
        if (PlayerAudio.isPlaying == false)
        {
            PlayerAudio.PlayOneShot(InfiniteLoop, Volume);
        }
    }


    void OnTriggerStay(Collider PlayerCollision) // Collision by tag
    {
        if (CameraObject != null)
        {

            if (PlayerCollision.tag == "Hit")
            {

                ShakeHit_Sound();
                TimeShake += TimeShakeFromHit;
                Destroy(PlayerCollision.gameObject);

            }

            if (PlayerCollision.tag == "Infinite")
            {

                Infinite = true;
                InfiniteLoop_Sound();
            }
        }
    }


    void OnTriggerExit(Collider PlayerCollisionExit) // Collision by tag - Exit. For the effect to stop.
    {
        if (CameraObject != null)
        {
            if (PlayerCollisionExit.tag == "Infinite")
            {

                PlayerAudio.Stop();
                Infinite = false;

            }
        }
    }















}
