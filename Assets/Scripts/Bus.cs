using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bus : MonoBehaviour {

	public Transform destination;
	public float speed;
	public AudioClip bus1;
	public static bool shouldDrive = false;
	private static bool hasStarted = false;
	private AudioSource bSound;

	void Start () {
		bSound = GetComponent<AudioSource>();
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
		if(!bSound.isPlaying) {
			bSound.PlayOneShot(bus1, 0.7F);
		}
	}
}
