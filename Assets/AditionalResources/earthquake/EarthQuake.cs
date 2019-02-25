using UnityEngine;
using System.Collections;

public class EarthQuake : MonoBehaviour
{
	[UnityEngine.SerializeField, Range(1f, 50f)]
	public float magnitude = 9f;
	[UnityEngine.SerializeField, Range(0f, 100f)]
	public float shakingSpeed = 20;
	[UnityEngine.SerializeField, Range(0f, 1f)]
	public float randomAmount = 0.5f;
	public float duration = 10;
	public Vector3 forceByAxis;
	public AnimationCurve forceOverTime;
	public bool forceRecenter = true;
	public bool loop = false;
	[SerializeField]
	string currentState;

    public Rigidbody rb;

    bool running = true;
	public bool Running
	{
		get { return running; }
		set { startStop(value); }
	}

	Vector3 startPosition;
	Vector3 delta;
	[SerializeField]
	float currentMagnitude;
	float timeSinceStarted;

	// Use this for initialization
	void Start ()
	{
		startPosition = transform.position;
		try { rb = gameObject.AddComponent<Rigidbody>(); } catch {};
		rb.mass = float.MaxValue;
        rb.useGravity = false;
        Running = true;

	}

	void startStop(bool value)
	{
		if (value)
			currentState = "quake started";
		else
			currentState = "quake stopped";
		currentMagnitude = 0;
		timeSinceStarted = 0;
		running = value;
        rb.velocity = Vector3.zero;
		delta = Vector3.zero;
	}

	void OnRunning()
	{
		forceByAxis = new Vector3(Mathf.Clamp(forceByAxis.x, 0f, 1f),
		                          Mathf.Clamp(forceByAxis.y, 0f, 1f),
		                          Mathf.Clamp(forceByAxis.z, 0f, 1f));
		timeSinceStarted += Time.deltaTime;
		currentMagnitude = forceOverTime.Evaluate(timeSinceStarted / duration) * magnitude * 15;
		if (timeSinceStarted > duration && !loop)
			Running = false;
		if (timeSinceStarted > duration && loop)
			Running = true;
		delta += new Vector3(Time.deltaTime * shakingSpeed * my_rand(),
		                     Time.deltaTime * shakingSpeed * my_rand(),
		                     Time.deltaTime * shakingSpeed * my_rand());
        rb.velocity = new Vector3(Mathf.Cos(delta.x) * Time.deltaTime * currentMagnitude * forceByAxis.x,
		                                 Mathf.Cos(delta.y) * Time.deltaTime * currentMagnitude * forceByAxis.y,
		                                 Mathf.Cos(delta.z) * Time.deltaTime * currentMagnitude * forceByAxis.z);
		currentMagnitude /= 15;
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
        rb.velocity = Vector3.zero;
		if (running)
			OnRunning();
		if (forceRecenter)
            rb.velocity += (startPosition - transform.position) * Time.deltaTime * 40;
	}

	float my_rand()
	{
		return (1f - Random.Range(0, randomAmount));
	}
}
