using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bus : MonoBehaviour {

	public Transform destination;
	public float speed;

	public void Drive() {
		transform.position = Vector3.Lerp (transform.position, destination.position, speed);
	}
}
