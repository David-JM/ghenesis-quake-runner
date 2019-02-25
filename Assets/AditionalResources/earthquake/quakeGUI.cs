using UnityEngine;
using System.Collections;

public class quakeGUI : MonoBehaviour
{
	public GameObject toInstantiate;
	public GameObject[] floors;
	GameObject currentFloor;
	EarthQuake eq;

	// Use this for initialization
	void Start ()
	{
		changeType(0);
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	void OnGUI()
	{
		Rect rt = new Rect(10, Screen.height - 50, 150, 20);
		GUI.Label(rt, "magnitude: " + eq.magnitude);
		rt.x += 100;
		eq.magnitude = GUI.HorizontalSlider(rt, eq.magnitude, 0, 50); 
		rt.x -= 100; rt.y -= 30;
		GUI.Label(rt, "shake speed: " + eq.shakingSpeed);
		rt.x += 100;
		eq.shakingSpeed = GUI.HorizontalSlider(rt, eq.shakingSpeed, 0, 100); 
		rt.x -= 100; rt.y -= 30;
		GUI.Label(rt, "rand amount: " + eq.randomAmount);
		rt.x += 100;
		eq.randomAmount = GUI.HorizontalSlider(rt, eq.randomAmount, 0f, 1f);
		rt.x -= 100; rt.y -= 30;
		if (GUI.Button(rt, "start / stop earthquake"))
		{
			eq.Running = !eq.Running;
			if (eq.Running == false)
			{
				try
				{
					GameObject obj = GameObject.FindGameObjectWithTag("Respawn");
					GameObject.Destroy(obj);
					GameObject.Instantiate(toInstantiate, toInstantiate.transform.position, toInstantiate.transform.rotation);
				}
				catch {}
			}
		}
		rt.width = 75;
		rt.x += 160;
		if (GUI.Button(rt, "earthquake"))
			changeType(0);
		rt.x += 80;
		if (GUI.Button(rt, "explosion"))
			changeType(1);
		rt.x += 80;
		if (GUI.Button(rt, "giant walk"))
			changeType(2);

	}

	public void changeType(int t)
	{
		try {
			GameObject.Destroy(currentFloor);
		}
		catch {}
		currentFloor = GameObject.Instantiate(floors[t], floors[t].transform.position, floors[t].transform.rotation) as GameObject;
		eq = currentFloor.GetComponent<EarthQuake>();
	}
}
