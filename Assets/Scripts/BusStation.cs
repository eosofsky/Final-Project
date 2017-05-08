using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusStation : MonoBehaviour {

	public static bool hasLoaded = false;
	public static bool busIsFixed = false;

	void Awake () {
		if (!hasLoaded) {
			AliceDialogue.Advance ();
		}
		hasLoaded = true;
	}

	void Start () {
		if (busIsFixed) {
			Destroy (GameObject.Find ("out_of_order"));
			Bus.shouldDrive = true;
		}
	}

}
