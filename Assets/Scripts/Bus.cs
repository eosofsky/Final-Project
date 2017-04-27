using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bus : MonoBehaviour {

	public Transform destination;
	public float speed;
	public static bool shouldDrive = false;
	private static bool hasStarted = false;

	void Start () {
		if (hasStarted && shouldDrive) {
			transform.position = destination.position;
		}
		hasStarted = true;
	}

	void Update () {
		if (shouldDrive) {
			Drive ();
		}
	}

	public void Drive() {
		transform.position = Vector3.Lerp (transform.position, destination.position, speed);
	}
}
