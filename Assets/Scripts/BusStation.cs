using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusStation : MonoBehaviour {

	public static bool hasLoaded = false;

	void Awake () {
		if (!hasLoaded) {
			AliceDialogue.Advance ();
		}
		hasLoaded = true;
	}
}
