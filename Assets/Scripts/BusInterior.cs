using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusInterior : MonoBehaviour {

	public static bool hasLoaded = false;

	void Awake () {
		if (!hasLoaded) {
			HackerDialogue.Advance ();
		}
		hasLoaded = true;
	}
}
